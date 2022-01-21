using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTexter : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Logger.Instance.LogInfo("The debugger is working");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
