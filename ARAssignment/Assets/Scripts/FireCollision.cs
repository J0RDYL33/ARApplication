using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class FireCollision : MonoBehaviour
{
    public GameObject steamObject;
    public ARPlacementInteractable fireInteractable;
    public ARRaycastHit planeHit;
    public Pose pose;
    // Start is called before the first frame update
    void Start()
    {
        fireInteractable = FindObjectOfType<ARPlacementInteractable>();
        planeHit = fireInteractable.s_Hits[0];
        pose = planeHit.pose;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "water")
        {
            Logger.Instance.LogInfo("Collision happened between fire and water");
            Debug.Log("Collision happened between fire and water");
            Destroy(other.gameObject);
            Logger.Instance.LogInfo("Destroyed water");

            SpawnOnCollision(steamObject);

            Destroy(this.gameObject);
            Logger.Instance.LogInfo("Destroyed fire");
        }
    }

    public void SpawnOnCollision(GameObject newObject)
    {
        Pose pose;
        pose = this.pose;
        GameObject newSteam = Instantiate(newObject, this.transform.position, this.transform.rotation);
        Logger.Instance.LogInfo("Spawned steam");
        var anchor = new GameObject("PlacementAnchor").transform;
        anchor.position = pose.position;
        anchor.rotation = pose.rotation;
        newSteam.transform.parent = anchor;
        Logger.Instance.LogInfo("Pose section complete, " + pose);
        Debug.Log("Pose section complete, " + pose);

        ARObjectPlacementEventArgs m_ObjectPlacementEventArgs = new ARObjectPlacementEventArgs();
        m_ObjectPlacementEventArgs.placementInteractable = fireInteractable;
        m_ObjectPlacementEventArgs.placementObject = newSteam;
        Logger.Instance.LogInfo("Setting placement event args complete, " + m_ObjectPlacementEventArgs);
        Debug.Log("Setting placement event args complete, " + m_ObjectPlacementEventArgs);

        ARObjectPlacementEvent m_ObjectPlaced = new ARObjectPlacementEvent();
        ARObjectPlacedEvent m_OnObjectPlaced = new ARObjectPlacedEvent();
        m_ObjectPlaced?.Invoke(m_ObjectPlacementEventArgs);
        m_OnObjectPlaced?.Invoke(m_ObjectPlacementEventArgs.placementInteractable, m_ObjectPlacementEventArgs.placementObject);
        Logger.Instance.LogInfo("Invoking complete, " + m_ObjectPlaced);
        Debug.Log("Invoking complete, " + m_ObjectPlaced);
    }
}
