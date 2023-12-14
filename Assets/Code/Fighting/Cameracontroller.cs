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
    private float camypos = 0;
    void Start()
    {
        t1 = p1.GetComponent<Transform>();
        t2 = p2.GetComponent<Transform>();
        cam = GetComponent<Transform>();
    }

    
    void Update()
    {
        if (t1.position.x + t2.position.x > 5.6f)
        {
            camypos = 5.6f;
        }
        else if (t1.position.x + t2.position.x < -5.6f)
        {
            camypos = -5.6f;
        }
        else
        {
            camypos = t1.position.x + t2.position.x;
        }
        cam.position = new Vector3(camypos, 8.2f + (t1.position.y-3.7f)/10+(t2.position.y-3.7f)/10, cam.position.z);
    }
}
