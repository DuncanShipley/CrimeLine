using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facecam : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Guard")
        {
            door1.GetComponent<doorcodeA>().updateFaceID(true);
            door2.GetComponent<doorcodeA>().updateFaceID(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Guard")
        {
            door1.GetComponent<doorcodeA>().updateFaceID(false);
            door2.GetComponent<doorcodeA>().updateFaceID(false);
        }
    }
}
