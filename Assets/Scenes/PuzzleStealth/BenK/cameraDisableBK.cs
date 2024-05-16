using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraDisableBK : MonoBehaviour
{
    private GameObject[] cams;
    private bool touch;

    // Start is called before the first frame update
    void Start()
    {
        cams = GameObject.FindGameObjectsWithTag("camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && touch) 
        {
            for(int i = 0; i < cams.Length; i++)
            {
                Destroy(cams[i]);
            }

            cams = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            touch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touch = false;
    }
}
