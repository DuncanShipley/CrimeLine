using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollowT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GameObject.Find("Player").transform.position + new Vector3(0, 1, -5);
    }

}
