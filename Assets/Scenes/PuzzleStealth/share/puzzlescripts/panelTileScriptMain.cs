using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelTileScriptMain : MonoBehaviour
{
    public Sprite on;
    public Sprite off;
    private Image image;

    void Start()
    {
        image = gameObject.GetComponent<Image>();
        image.sprite = off;
    }

    public void toggleState()
    {
        if(getState())
        {
            image.sprite = off;
        }
        else
        {
            image.sprite = on;
        }
    }

    public bool getState()
    {
        if(image.sprite == on)
        {
            return true;
        } 
        else
        {
            return false;
        }
    }
}
