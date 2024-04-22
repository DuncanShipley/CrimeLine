using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class objectiveTrackerBK : MonoBehaviour
{
    // Public vars
    public Sprite on;
    public Sprite off;
    public string[] lines;
    public static GameObject[] allObjectives = new GameObject[5];
    public static GameObject[] allTexts = new GameObject[5];

    // Tracking objective stage
    public int objStage = 0;

    // Obj refs
    public static objectiveTrackerBK currentObjective;
    private GameObject cloneObj;
    private GameObject cloneText;
    public GameObject thisText;
    private InputControllerBK input;

    // Start is called before the first frame update
    void Start()
    {
        objectiveTrackerBK.currentObjective = gameObject.GetComponent<objectiveTrackerBK>();
        input = GameObject.Find("UI").GetComponent<InputControllerBK>();


        allObjectives[objStage] = gameObject;
        allTexts[objStage] = thisText;
    }

    // Update is called once per frame
    void Update()
    {
        if (thisText.GetComponent<TextMeshProUGUI>().text != lines[objStage])
        {
            thisText.GetComponent<TextMeshProUGUI>().SetText(lines[objStage]);
        }
    }

    public void completeObjective(int stageToComplete)
    {
        if (stageToComplete < objStage)
        {
            return;
        }

        if (stageToComplete == objStage)
        {
            gameObject.GetComponent<Image>().sprite = on;

            // Create the next objective if there's one left
            if (objStage + 1 < lines.Length)
            {
                cloneObj = Object.Instantiate(gameObject, GameObject.Find("UI").transform);
                cloneText = Object.Instantiate(thisText, GameObject.Find("UI").transform);

                cloneObj.GetComponent<Image>().sprite = off;
                cloneObj.GetComponent<objectiveTrackerBK>().thisText = cloneText;
                cloneObj.GetComponent<objectiveTrackerBK>().objStage++;

                for (int i = 0; i < allObjectives.Length; i++)
                {
                    if (allObjectives[i] != null)
                    {
                        allObjectives[i].transform.position = new Vector3(allObjectives[i].transform.position.x, allObjectives[i].transform.position.y - 50f, allObjectives[i].transform.position.z);
                        allObjectives[i].GetComponent<Image>().color = new Color(1f, 1f, 1f, allObjectives[i].GetComponent<Image>().color.a - 0.25f);
                    }
                }
                for (int i = 0; i < allTexts.Length; i++)
                {
                    if (allTexts[i] != null)
                    {
                        allTexts[i].transform.position = new Vector3(allTexts[i].transform.position.x, allTexts[i].transform.position.y - 50f, allTexts[i].transform.position.z);
                        allTexts[i].GetComponent<TextMeshProUGUI>().color = new Color(1f, 1f, 1f, allTexts[i].GetComponent<TextMeshProUGUI>().color.a - 0.25f);
                    }
                }

                objectiveTrackerBK.currentObjective = cloneObj.GetComponent<objectiveTrackerBK>();
                allObjectives[cloneObj.GetComponent<objectiveTrackerBK>().objStage] = cloneObj;
                allTexts[cloneObj.GetComponent<objectiveTrackerBK>().objStage] = cloneText;
            }

        }
    }
}
