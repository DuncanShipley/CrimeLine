using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class signalJammerTesla : MonoBehaviour
{
    private bool placed = false;
    private float time;
    float intense;
    private GameObject[] cams;
    private GameObject playerLight;

    void Start()
    {
        cams = GameObject.FindGameObjectsWithTag("camera");
        playerLight = GameObject.Find("Player Light");
    }
    // Start is called before the first frame update
    void Update()
    {
        if(placed == true) 
        {
            time++;
            playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = (Mathf.Cos(time/20) + 1) * 0.5f;
            

            for(int i = 0; i < cams.Length; i++)
            {
                cams[i].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = Mathf.Sin(time/4) + 1;
            }
            
            if(time >= 210)
            {
                playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 0.5f;
                playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = Color.white;
                for(int i = 0; i < cams.Length; i++)
                {
                    cams[i].GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 3f;
                }
                placed = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Guard")
        {
            gameObject.SetActive(false);
        }
    }

    public void deploy()
    {
        playerLight.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = Color.cyan;
        placed = true;
    }
}
