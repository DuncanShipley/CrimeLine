using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class talkscriptA : MonoBehaviour
{
    public string[] lines;
    public bool key;
    public bool objective;
    public int objectiveStage;
    public bool item;
    public GameObject itemObject;

    private bool talking = false;
    private int totalLines;
    private int textIndex = 0;

    private InputControllerA input;
    private TextMeshProUGUI text;
    private bigTextboxMain textbox;
    private camfollowA camera;
    private KeychainA keychain;
    private itemSelector inv;
    bool touch = false;

    // Start is called before the first frame update
    void Start()
    {
        totalLines = lines.Length;
        camera = GameObject.Find("Main Camera").GetComponent<camfollowA>();
        textbox = GameObject.Find("bigTextbox").GetComponent<bigTextboxMain>();
        keychain = GameObject.Find("Player").GetComponent<KeychainA>();
        inv = GameObject.Find("IScursor").GetComponent<itemSelector>();

        input = GameObject.Find("ScreenUI").GetComponent<InputControllerA>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.GetKeyLimited("z") && touch && !talking)
        {
            talking = true;
            textbox.pushText(lines);

            if (objective)
            {
                objectiveTrackerA.currentObjective.completeObjective(objectiveStage);
            }
            if (key)
            {
                keychain.addKey();
            }
            if (item)
            {
                Debug.Log(itemObject);
                inv.AddItem(itemObject);
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
