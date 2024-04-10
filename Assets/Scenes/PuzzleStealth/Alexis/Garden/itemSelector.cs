using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemSelector : MonoBehaviour
{
    private RectTransform pos;
    private float v;
    private float h;
    private float x;
    private float y;
    private bool menuOpen;

    public GameObject[] heldObjects = new GameObject[8];
    public GameObject heldObject = null;
    public GameObject uiSprite;

    // Start is called before the first frame update
    void Start()
    {
        pos = gameObject.GetComponent<RectTransform>();
        for(int i = 0; i < 8; i++) {
            heldObjects[i] = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        MakeColors();
        if(Input.GetKey(KeyCode.C))
        {
            MakeMovement();
        }
        if(menuOpen && !Input.GetKey(KeyCode.C))
        {
            SelectItem();
        }
    }

    void MakeMovement() {

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        x = pos.anchoredPosition.x;
        y = pos.anchoredPosition.y;
        menuOpen = true;

        if (h > 0 && x < 60)
        {
            h = 10;
        }
        else if (h < 0 && x > -60)
        {
            h = -10;
        } 
        else
        {
            h = 0;
        }

        if (v > 0 && y < 60)
        {
            v = 10;
        }
        else if (v < 0 && y > -60)
        {
            v = -10;
        }
        else
        {
            v = 0;
        }

        pos.anchoredPosition = new Vector2(x + h, y + v);
    }

    void MakeColors() 
    {
        if(Input.GetKey(KeyCode.C))
        {
            GameObject.Find("itemSelector").GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            GameObject.Find("IScursor").GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            for(int i = 0; i < 8; i++) {
                if(heldObjects[i])
                    heldObjects[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            }

            
        }
        else if (GameObject.Find("itemSelector").GetComponent<Image>().color.a > 0)
        {
            GameObject.Find("itemSelector").GetComponent<Image>().color = new Color(1f, 1f, 1f, GameObject.Find("itemSelector").GetComponent<Image>().color.a - 0.05f);
            GameObject.Find("IScursor").GetComponent<Image>().color = new Color(1f, 1f, 1f, GameObject.Find("IScursor").GetComponent<Image>().color.a - 0.05f);
            for(int i = 0; i < 8; i++) {
                if(heldObjects[i])
                    heldObjects[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, heldObjects[i].GetComponent<Image>().color.a - 0.05f);
            }


        }
        else
        {
            pos.anchoredPosition = new Vector2(0, 0);
        }
    }

    void SelectItem() 
    {
        if(!Input.GetKey(KeyCode.C) && menuOpen) 
        {
            x = pos.anchoredPosition.x;
            y = pos.anchoredPosition.y;

            Debug.Log(x);
            Debug.Log(y);
            if(x > 30) 
            {
                if(y > 30)
                {
                    AssignItem(heldObjects[1]);
                }
                else if(y < -30)
                {
                    AssignItem(heldObjects[3]);
                }
                else
                {
                    AssignItem(heldObjects[2]);
                }
            }
            else if(x < -30)
            {
                if(y > 30)
                {
                    AssignItem(heldObjects[6]);
                }
                else if(y < -30)
                {
                    AssignItem(heldObjects[4]);
                }
                else
                {
                    AssignItem(heldObjects[5]);
                }
            }
            else
            {
                if(y > 30)
                {
                    AssignItem(heldObjects[0]);
                }
                else if(y < -30)
                {
                    AssignItem(heldObjects[4]);
                }
            }

            menuOpen = false;
        }
    }

    void AssignItem(GameObject item)
    {
        if(item)
        {
            heldObject = item;
            GameObject.Find("heldItem").GetComponent<Image>().sprite = item.GetComponent<Image>().sprite;
        }
    }

    public void AddItem(GameObject item)
    {
        int itemPos = -1;
        int x = 0;
        int y = 0;

        for(int i = 0; i < 8; i++)
        {
            if(!heldObjects[i])
            {
                itemPos = i;
                heldObjects[i] = item;
                break;
            }
        }

        if(itemPos != -1)
        {
            switch(itemPos)
            {
                case 0:
                    x = 0;
                    y = 90;
                    break;
                
                case 1:
                    x = 60;
                    y = 60;
                    break;

                case 2:
                    x = 90;
                    y = 0;
                    break;

                case 3:
                    x = 60;
                    y = -60;
                    break;

                case 4:
                    x = 0;
                    y = -90;
                    break;

                case 5:
                    x = -60;
                    y = -60;
                    break;

                case 6:
                    x = -90;
                    y = 0;
                    break;

                case 7:
                    x = -60;
                    y = 60;
                    break;
            }

            heldObjects[itemPos] = Instantiate(uiSprite, GameObject.Find("itemSelector").GetComponent<Transform>());
            heldObjects[itemPos].GetComponent<Image>().sprite = item.gameObject.GetComponent<SpriteRenderer>().sprite;
            heldObjects[itemPos].GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
            heldObjects[itemPos].GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            heldObjects[itemPos].GetComponent<RectTransform>().sizeDelta = new Vector2(48, 48);
        }
    }
}
