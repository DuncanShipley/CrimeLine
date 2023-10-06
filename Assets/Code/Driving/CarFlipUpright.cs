using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFlipUpright : MonoBehaviour
{

    [SerializeField] private GameObject Car;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            Car.transform.Rotate(0, 0, 180, Space.Self);
        }
    }
}
