using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class talkscriptBK : MonoBehaviour
{
    public string[] lines;
    public bool objective;
    public int objectiveStage;

    private bool talking = false;
    private int totalLines;
    private int textIndex = 0;

    private InputControllerBK input;
    private TextMeshProUGUI text;
    private GameObject textobj;
    private GameObject textbox;
    private camfollowBK camera;
    bool touch = false;

    // Start is called before the first frame update
    void Start()
    {
        totalLines = lines.Length;
        camera = GameObject.Find("Main Camera").GetComponent<camfollowBK>();
        textobj = GameObject.Find("bigText");
        textbox = GameObject.Find("bigTextbox");
        text = textobj.GetComponent<TextMeshProUGUI>();

        input = GameObject.Find("UI").GetComponent<InputControllerBK>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.GetKeyLimited("z") && (touch || false))
        {
            if (textbox.GetComponent<bigTextbox>().enabled)
            {
                textIndex++;
                if (textIndex >= totalLines)
                {
                    if (objective)
                    {
                        objectiveTracker.currentObjective.completeObjective(objectiveStage);
                    }
                    textbox.GetComponent<bigTextbox>().enabled = false;
                    textobj.GetComponent<bigTextbox>().enabled = false;
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
                textbox.GetComponent<bigTextbox>().enabled = true;
                textobj.GetComponent<bigTextbox>().enabled = true;
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
