using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facecamAlexis : MonoBehaviour
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
        if (other.tag == "Player")
        {
            door1.GetComponent<doorcodeAlexis>().updateFaceID(true);
            door2.GetComponent<doorcodeAlexis>().updateFaceID(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            door1.GetComponent<doorcodeAlexis>().updateFaceID(false);
            door2.GetComponent<doorcodeAlexis>().updateFaceID(false);
        }
    }
}
