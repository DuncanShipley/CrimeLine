using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinnySteelButtonAlexis : MonoBehaviour
{
    public Sprite on;
    public Sprite off;
    private GameObject[] buttons1;
    private GameObject[] spinnySteels1;
    private GameObject[] buttons2;
    private GameObject[] spinnySteels2;
    private bool touch;

    // Start is called before the first frame update
    void Start()
    {
        buttons1 = GameObject.FindGameObjectsWithTag("button1");
        spinnySteels1 = GameObject.FindGameObjectsWithTag("spinnySteel1");
        buttons2 = GameObject.FindGameObjectsWithTag("button2");
        spinnySteels2 = GameObject.FindGameObjectsWithTag("spinnySteel2");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && touch)
        {
            if(gameObject.tag == "button1")
            {
                for(int i = 0; i < buttons1.Length; i++)
                {
                    if(buttons1[i].GetComponent<SpriteRenderer>().sprite == on)
                    {
                        buttons1[i].GetComponent<SpriteRenderer>().sprite = off;
                    }
                    else
                    {
                        buttons1[i].GetComponent<SpriteRenderer>().sprite = on;
                    }
                }

                for(int i = 0; i < spinnySteels1.Length; i++)
                {
                    if(spinnySteels1[i].transform.rotation.z >= 270)
                    {
                        spinnySteels1[i].transform.Rotate(0, 0, -270, Space.Self);
                    }
                    else
                    {
                        spinnySteels1[i].transform.Rotate(0, 0, 90, Space.Self);
                    }
                }
            }
            else if (gameObject.tag == "button2")
            {
                for(int i = 0; i < buttons2.Length; i++)
                {
                    if(buttons2[i].GetComponent<SpriteRenderer>().sprite == on)
                    {
                        buttons2[i].GetComponent<SpriteRenderer>().sprite = off;
                    }
                    else
                    {
                        buttons2[i].GetComponent<SpriteRenderer>().sprite = on;
                    }
                }

                for(int i = 0; i < spinnySteels2.Length; i++)
                {
                    if(spinnySteels2[i].transform.rotation.z >= 270)
                    {
                        spinnySteels2[i].transform.Rotate(0, 0, -270, Space.Self);
                    }
                    else
                    {
                        spinnySteels2[i].transform.Rotate(0, 0, 90, Space.Self);
                    }
                }
            }
            
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
