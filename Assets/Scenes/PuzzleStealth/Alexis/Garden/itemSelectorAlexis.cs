using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemSelectorAlexis : MonoBehaviour
{
    private RectTransform pos;
    private float v;
    private float h;
    private float x;
    private float y;
    private bool menuOpen;

    public GameObject[] heldItemSprites = new GameObject[8];
    public GameObject[] heldItemObjects = new GameObject[8];
    public GameObject heldObject = null;
    public GameObject uiSprite;
    public Sprite emptyItemSprite;

    // Start is called before the first frame update
    void Start()
    {
        pos = gameObject.GetComponent<RectTransform>();
        for(int i = 0; i < 8; i++) {
            heldItemSprites[i] = null;
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
        if(menuOpen && !Input.GetKey(KeyCode.C) && GetCursorPos() >= 0)
        {
            SelectItem(GetCursorPos());
        }
        if(Input.GetKeyDown(KeyCode.X) && GetCursorPos() >= 0)
        {
            UseItem(GetCursorPos());
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

    void UpdateSprites()
    {
        for(int i = 0; i < 8; i++)
        {
            heldItemSprites[i].GetComponent<Image>().sprite = heldItemObjects[i].GetComponent<SpriteRenderer>().sprite;
            
            if(heldItemObjects[i] != null)
            {
                
            }
        }
    }

    void MakeColors() 
    {
        if(Input.GetKey(KeyCode.C))
        {
            GameObject.Find("itemSelector").GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            GameObject.Find("IScursor").GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            for(int i = 0; i < 8; i++) {
                if(heldItemSprites[i])
                    heldItemSprites[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            }

            
        }
        else if (GameObject.Find("itemSelector").GetComponent<Image>().color.a > 0)
        {
            GameObject.Find("itemSelector").GetComponent<Image>().color = new Color(1f, 1f, 1f, GameObject.Find("itemSelector").GetComponent<Image>().color.a - 0.05f);
            GameObject.Find("IScursor").GetComponent<Image>().color = new Color(1f, 1f, 1f, GameObject.Find("IScursor").GetComponent<Image>().color.a - 0.05f);
            for(int i = 0; i < 8; i++) {
                if(heldItemSprites[i])
                    heldItemSprites[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, heldItemSprites[i].GetComponent<Image>().color.a - 0.05f);
            }


        }
        else
        {
            pos.anchoredPosition = new Vector2(0, 0);
        }
    }

    void SelectItem(int id) 
    {
        if(!Input.GetKey(KeyCode.C) && menuOpen ) 
        {
            x = pos.anchoredPosition.x;
            y = pos.anchoredPosition.y;
            AssignItem(heldItemSprites[id]);
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

    void UseItem(int id)
    {
        if(heldItemObjects[id])
        {
            bool toDestroy = itemsAlexis.UseItem(heldItemObjects[id]);

            if(toDestroy)
            {
                Destroy(heldItemSprites[id]);
                heldItemObjects[id] = null;
                heldItemSprites[id] = null;
                heldObject = null;
                GameObject.Find("heldItem").GetComponent<Image>().sprite = emptyItemSprite;
            }
        }
    }

    int GetCursorPos() 
    {
        if(x > 30) 
        {
            if(y > 30)
            {
                return 1;
            }
            else if(y < -30)
            {
                return 3;
            }
            else
            {
                return 2;
            }
        }
        else if(x < -30)
        {
            if(y > 30)
            {
                return 7;
            }
            else if(y < -30)
            {
                return 5;
            }
            else
            {
                return 6;
            }
        }
        else
        {
            if(y > 30)
            {
                return 0;
            }
            else if(y < -30)
            {
                return 4;
            }
        }

        return -1;
    }

    public void AddItem(GameObject item)
    {
        int itemPos = -1;
        int x = 0;
        int y = 0;

        for(int i = 0; i < 8; i++)
        {
            if(!heldItemSprites[i])
            {
                itemPos = i;
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
            heldItemObjects[itemPos] = item;

            heldItemSprites[itemPos] = Instantiate(uiSprite, GameObject.Find("itemSelector").GetComponent<Transform>());
            heldItemSprites[itemPos].GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
            heldItemSprites[itemPos].GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            heldItemSprites[itemPos].GetComponent<RectTransform>().sizeDelta = new Vector2(48, 48);
            heldItemSprites[itemPos].GetComponent<Image>().sprite = heldItemObjects[itemPos].GetComponent<SpriteRenderer>().sprite;
        }
    }
}
