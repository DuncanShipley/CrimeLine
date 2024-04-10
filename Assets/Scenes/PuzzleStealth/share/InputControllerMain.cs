using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControllerMain : MonoBehaviour
{
    bool zReady = true;
    bool zTrigger = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z) && zReady)
        {
            zTrigger = true;
            zReady = false;
        } 
        else if(!Input.GetKey(KeyCode.Z))
        {
            zTrigger = false;
            zReady = true;
        } else
        {
            zTrigger = false;
            zReady = false;
        }
    }

    public bool GetKeyLimited(string key)
    {
        switch (key) 
        {
            case "z":
                return zTrigger;
            default:
                return false;
        }
        
    }
}
