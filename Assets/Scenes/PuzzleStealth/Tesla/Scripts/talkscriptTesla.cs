using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class talkscriptTesla : MonoBehaviour
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

    private TextMeshProUGUI text;
    private bigTextboxTesla textbox;
    private camfollowTesla camera;
    private KeychainTesla keychain;
    private itemSelectorTesla inv;
    bool touch = false;

    // Start is called before the first frame update
    void Start()
    {
        totalLines = lines.Length;
        camera = GameObject.Find("Tesla Camera").GetComponent<camfollowTesla>();
        textbox = GameObject.Find("bigTextbox").GetComponent<bigTextboxTesla>();
        keychain = GameObject.Find("Player").GetComponent<KeychainTesla>();
        inv = GameObject.Find("IScursor").GetComponent<itemSelectorTesla>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && touch && !talking)
        {
            talking = true;
            textbox.pushText(lines);

            if (objective)
            {
                objectiveTrackerTesla.currentObjective.completeObjective(objectiveStage);
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
