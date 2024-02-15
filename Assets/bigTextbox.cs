using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigTextbox : MonoBehaviour
{
    public bool enabled;
    bool keyDown = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enabled)
        {
            if (transform.position.y < 70)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 20f, transform.position.z);
            }
        }
        else
        {
            if (transform.position.y > -130)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 20f, transform.position.z);
            }
        }

        if(Input.GetKey(KeyCode.T) && !keyDown)
        {
            if(enabled)
            {
                enabled = false;
                GameObject.Find("Main Camera").GetComponent<camfollow>().enable();
            }
            else
            {
                enabled = true;
                GameObject.Find("Main Camera").GetComponent<camfollow>().disable();
            }

            keyDown = true;
        }
        else if(!Input.GetKey(KeyCode.T))
        {
            keyDown = false;
        }
    }
}