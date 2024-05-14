using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class objectiveTrackerMain : MonoBehaviour
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
    public static objectiveTrackerMain currentObjective;
    private GameObject cloneObj;
    private GameObject cloneText;
    public GameObject thisText;
    private InputControllerMain input;

    // Start is called before the first frame update
    void Start()
    {
        objectiveTrackerMain.currentObjective = gameObject.GetComponent<objectiveTrackerMain>();
        input = GameObject.Find("Screen UI").GetComponent<InputControllerMain>();


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
                cloneObj = Object.Instantiate(gameObject, GameObject.Find("ScreenUI").transform);

                cloneObj.GetComponent<Image>().sprite = off;
                cloneObj.GetComponent<objectiveTrackerMain>().objStage++;

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
                        allTexts[i].GetComponent<TextMeshProUGUI>().color = new Color(1f, 1f, 1f, allTexts[i].GetComponent<TextMeshProUGUI>().color.a - 0.25f);
                    }
                }

                objectiveTrackerMain.currentObjective = cloneObj.GetComponent<objectiveTrackerMain>();
                allObjectives[cloneObj.GetComponent<objectiveTrackerMain>().objStage] = cloneObj;
                allTexts[cloneObj.GetComponent<objectiveTrackerMain>().objStage] = cloneText;
            }

        }
    }
}
