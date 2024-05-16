using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class talkscriptBK : MonoBehaviour
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
    private bigTextboxBK textbox;
    private camfollowBK camera;
    private KeychainBK keychain;
    private itemSelectorBK inv;
    bool touch = false;

    // Start is called before the first frame update
    void Start()
    {
        totalLines = lines.Length;
        camera = GameObject.Find("BK Camera").GetComponent<camfollowBK>();
        textbox = GameObject.Find("bigTextbox").GetComponent<bigTextboxBK>();
        keychain = GameObject.Find("Player").GetComponent<KeychainBK>();
        inv = GameObject.Find("IScursor").GetComponent<itemSelectorBK>();
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
                objectiveTrackerBK.currentObjective.completeObjective(objectiveStage);
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
