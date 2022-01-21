using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FireManager : MonoBehaviour
{
    public ARRaycastManager arRaycastManager;
    //Assign camera – should work with main tag but sometimes has issues
    public Camera arCamera;
    public GameObject firePrefab;
    private List<ARRaycastHit> arRaycastHits = new List<ARRaycastHit>();

    void Update()
    {
        if(Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                if (Input.touchCount == 1)
                {
                    Ray ray = arCamera.ScreenPointToRay(touch.position);

                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        if (hit.collider.tag == "fire")
                        {
                            DeleteFire(hit.collider.gameObject);
                            return;
                        }
                    }

                    if (arRaycastManager.Raycast(touch.position, arRaycastHits))
                    {
                        var pose = arRaycastHits[0].pose;
                        CreateFire(pose.position);
                        return;
                    }
                }
            }
        }
    }
    private void CreateFire(Vector3 position)
    {
        Instantiate(firePrefab, position, Quaternion.identity);
    }
    private void DeleteFire(GameObject fireObject)
    {
        Destroy(fireObject);
    }
}
