using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactAlexis : MonoBehaviour
{
    bool touch = false;
    bool space = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="interact"){
            touch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        touch = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            space = true;
        else
            space = false;
    }
    void FixedUpdate()
    {
        if (space && touch)
        {
            //Debug.Log("yes");
            space = false;
        }
        //else
            //Debug.Log("no");
    }
}
