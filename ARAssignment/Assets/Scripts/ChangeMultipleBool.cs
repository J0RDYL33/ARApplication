using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMultipleBool : MonoBehaviour
{
    public PlacementControllerWithMultiple myMultiple;
    // Start is called before the first frame update
    void Start()
    {
        myMultiple = FindObjectOfType<PlacementControllerWithMultiple>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToTrue()
    {
        Logger.Instance.LogInfo("Changed to true");
        myMultiple.isSelected = true;
    }

    public void ChangeToFalse()
    {
        Logger.Instance.LogInfo("Changed to false");
        myMultiple.isSelected = false;
    }
}

