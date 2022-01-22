using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class FireCollision : MonoBehaviour
{
    public GameObject steamObject;
    // Start is called before the first frame update
    void Start()
    {

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
            ARObjectPlacementEventArgs m_ObjectPlacementEventArgs = new ARObjectPlacementEventArgs();
            GameObject newSteam = Instantiate(steamObject, this.transform.position, this.transform.rotation);
            Logger.Instance.LogInfo("Spawned steam");
            Destroy(this.gameObject);
            Logger.Instance.LogInfo("Destroyed fire");
        }
    }
}
