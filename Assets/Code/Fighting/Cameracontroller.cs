using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameracontroller : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    Transform cam;
    Transform t1;
    Transform t2;
    void Start()
    {
        t1 = p1.GetComponent<Transform>();
        t2 = p2.GetComponent<Transform>();
        cam = GetComponent<Transform>();
    }

    
    void Update()
    {
        cam.position = new Vector3((t1.position.x+t2.position.x)/2,cam.position.y,cam.position.z);
    }
}
