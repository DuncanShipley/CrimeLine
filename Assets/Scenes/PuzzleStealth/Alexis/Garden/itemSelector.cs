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

    // Start is called before the first frame update
    void Start()
    {
        pos = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.C))
        {
            GameObject.Find("itemSelector").GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            GameObject.Find("IScursor").GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            x = pos.anchoredPosition.x;
            y = pos.anchoredPosition.y;

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
        else if (GameObject.Find("itemSelector").GetComponent<Image>().color.a > 0)
        {
            GameObject.Find("itemSelector").GetComponent<Image>().color = new Color(1f, 1f, 1f, GameObject.Find("itemSelector").GetComponent<Image>().color.a - 0.05f);
            GameObject.Find("IScursor").GetComponent<Image>().color = new Color(1f, 1f, 1f, GameObject.Find("IScursor").GetComponent<Image>().color.a - 0.05f);
        }
        else
        {
            pos.anchoredPosition = new Vector2(0, 0);
        }
            
    }
}
