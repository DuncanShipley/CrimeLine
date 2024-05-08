using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemsMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool UseItem(GameObject item) 
    {
        switch (item.name)
        {
            case "radio" :
                item.GetComponent<radioMain>().deploy();
                return true;
                break;
            case "signalJammer" :
                item.GetComponent<signalJammerMain>().deploy();
                return false;
                break;
            case "knife" :
                item.GetComponent<projectileMain>().deploy();
                return false;
                break;
        }

        return true;
    }
}
