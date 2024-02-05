using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDs : MonoBehaviour
{
    public static int ids = 0;
    public int publicId;

    // Start is called before the first frame update
    void Start()
    {
        publicId = ids;
        ids++;
    }

    public int GetID()
    {
        return publicId;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
