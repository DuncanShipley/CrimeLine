using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinnySteelButtonAlexis : MonoBehaviour
{
    public Sprite on;
    public Sprite off;
    private GameObject[] buttons;
    private GameObject[] spinnySteels;
    private bool touch;

    // Start is called before the first frame update
    void Start()
    {
        buttons = GameObject.FindGameObjectsWithTag("button");
        spinnySteels = GameObject.FindGameObjectsWithTag("spinnySteel");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && touch)
        {
            for(int i = 0; i < buttons.Length; i++)
            {
                if(buttons[i].GetComponent<SpriteRenderer>().sprite == on)
                {
                    buttons[i].GetComponent<SpriteRenderer>().sprite = off;
                }
                else
                {
                    buttons[i].GetComponent<SpriteRenderer>().sprite = on;
                }

                
            }

            for(int i = 0; i < spinnySteels.Length; i++)
            {
                if(spinnySteels[i].transform.rotation.z >= 270)
                {
                    spinnySteels[i].transform.Rotate(0, 0, -270, Space.Self);
                }
                else
                {
                    spinnySteels[i].transform.Rotate(0, 0, 90, Space.Self);
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
