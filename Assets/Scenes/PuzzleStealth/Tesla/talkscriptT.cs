using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class talkscriptT : MonoBehaviour
{
    public string[] lines;
    public bool objective;
    public int objectiveStage;

    private bool talking = false;
    private int totalLines;
    private int textIndex = 0;

    private InputControllerT input;
    private TextMeshProUGUI text;
    private GameObject textobj;
    private GameObject textbox;
    private camfollowT camera;
    bool touch = false;

    // Start is called before the first frame update
    void Start()
    {
        totalLines = lines.Length;
        camera = GameObject.Find("Main Camera").GetComponent<camfollowT>();
        textobj = GameObject.Find("bigText");
        textbox = GameObject.Find("bigTextbox");
        text = textobj.GetComponent<TextMeshProUGUI>();

        input = GameObject.Find("UI").GetComponent<InputControllerT>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.GetKeyLimited("z") && (touch || false))
        {
            if (textbox.GetComponent<bigTextboxT>().enabled)
            {
                textIndex++;
                if(textIndex >= totalLines)
                {
                    if(objective)
                    {
                        objectiveTrackerT.currentObjective.completeObjective(objectiveStage);
                    }
                    textbox.GetComponent<bigTextboxT>().enabled = false;
                    textobj.GetComponent<bigTextboxT>().enabled = false;
                    camera.enable();
                    textIndex = 0;
                }
                else
                {
                    text.SetText(lines[textIndex]);
                }
            } 
            else
            {
                textbox.GetComponent<bigTextboxT>().enabled = true;
                textobj.GetComponent<bigTextboxT>().enabled = true;
                text.SetText(lines[0]);
                camera.disable();
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
