using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemsBK : MonoBehaviour
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
                item.GetComponent<radioBK>().deploy();
                return true;
                break;
            case "signalJammer" :
                item.GetComponent<signalJammerBK>().deploy();
                return false;
                break;
            case "knife" :
                item.GetComponent<projectileBK>().deploy();
                return false;
                break;
        }

        return true;
    }
}
