using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bigTextboxAlexis : MonoBehaviour
{
    public bool enabled;
    public bool moving = false;
    public TextMeshProUGUI text;

    private List<string> textQueue = new List<string>();

    private camfollowAlexis camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<camfollowAlexis>();
    }

    // Update is called once per frame
    void Update()
    {
        makeMovements();

        if(textQueue.Count >= 1 && Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("hi");
            text.SetText(textQueue[0]);
            textQueue.RemoveAt(0);
        } 
        else if(Input.GetKeyDown(KeyCode.Z) && enabled & !moving)
        {
            enabled = false;
            moving = true;
            camera.enabled = true;
        }
    }

    void makeMovements()
    {
        if (enabled)
        {
            if (transform.position.y < 70)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 20f, transform.position.z);
                moving = true;
            }
            else
            {
                moving = false;

            }
        }
        else
        {
            if (transform.position.y > -130)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 20f, transform.position.z);
                moving = true;
            }
            else
            {
                moving = false;
            }
        }

       
    }

    public void pushText(string[] texts)
    {
        for (int i = 0; i < texts.Length; i++)
        {
            textQueue.Add(texts[i]);
        }

        text.SetText(textQueue[0]);
        textQueue.RemoveAt(0);
        enabled = true;
        camera.enabled = false;
    }

    public bool isTalking()
    {
        return enabled || moving;
    }
}
