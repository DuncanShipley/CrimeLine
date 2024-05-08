using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keysMain : MonoBehaviour
{
    public int heldkeys = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addKey()
    {
        heldkeys++;
    }
    public int getKeys()
    {
        return heldkeys;
    }
}
