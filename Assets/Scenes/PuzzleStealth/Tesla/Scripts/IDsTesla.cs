using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDsTesla : MonoBehaviour
{
    public static int ids = 0;
    public int publicId;

    void Start()
    {
        publicId = ids;
        ids++; // each guard assigns itself an id then increases the value for the next one
    }

    public int GetID()
    {
        return publicId; // make ID accessible from outside
    }
}
