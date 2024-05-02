using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class projectileMain : MonoBehaviour
{
    public bool fired = false;
    public int z;
    public Sprite[] sprites;
    public int knives = 3;

    private GameObject itemSprite;
    private bool leftPlayer = false;


    void Update()
    {
        if(fired)
        {
            Debug.Log(z);
            //Debug.Log(Math.Sin((double)transform.rotation.z * Math.PI / 180));
            GetComponent<Rigidbody2D>().MovePosition(transform.position + new Vector3(Mathf.Sin(z * Mathf.PI / 180) / 2, Mathf.Cos(z * Mathf.PI / 180) / 2, 0));
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[knives];
        }
    }

    public void deploy() 
    {
        if(knives > 0)
        {
            GameObject obj = GameObject.Instantiate(gameObject, GameObject.Find("Player").transform.position, transform.rotation);
            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, 0.5f);
            obj.GetComponent<SpriteRenderer>().sprite = sprites[1];
            obj.GetComponent<projectileMain>().makeRotation();
            obj.GetComponent<projectileMain>().fired = true;

            subtractKnife();
        }
        
    }

    private void makeRotation() 
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                z = 45;
                transform.Rotate(0, 0, 315, Space.Self);
            }
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                z = 135;
                transform.Rotate(0, 0, 225, Space.Self);
            }
            else
            {
                z = 90;
                transform.Rotate(0, 0, 270, Space.Self);
            }
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                z = 315;
                transform.Rotate(0, 0, 45, Space.Self);
            }
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                z = 225;
                transform.Rotate(0, 0, 135, Space.Self);
            }
            else
            {
                z = 270;
                transform.Rotate(0, 0, 90, Space.Self);
            }
        }
        else
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                z = 0;
                transform.Rotate(0, 0, 0, Space.Self);
            }
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                z = 180;
                transform.Rotate(0, 0, 180, Space.Self);
            }
            else
            {
                z = 0;
                transform.Rotate(0, 0, 0, Space.Self);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && leftPlayer && fired)
        {
            GameObject.Find("knife").GetComponent<projectileMain>().addKnife();
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            leftPlayer = true;
        }
    }

    public void addKnife()
    {
        if(knives < 3)
        {
            knives++;
            GameObject.Find("heldItem").GetComponent<Image>().sprite = sprites[knives];
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[knives];
        }
    }

    public void subtractKnife()
    {
        if(knives > 0)
        {
            knives--;
            GameObject.Find("heldItem").GetComponent<Image>().sprite = sprites[knives];
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[knives];
        }
    }
}
