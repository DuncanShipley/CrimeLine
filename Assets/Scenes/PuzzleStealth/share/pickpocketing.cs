using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pickpocketing : MonoBehaviour
{
    public int heldKey;

    private int pickProgress = 0;
    private Image textbox;
    private TextMeshProUGUI text;
    private Keychain keychain;
    private bool touch;

    // Start is called before the first frame update
    void Start()
    {
        textbox = GameObject.Find("playerTextbox").GetComponent<Image>();
        text = GameObject.Find("playerText").GetComponent<TextMeshProUGUI>();
        keychain = GameObject.Find("Player").GetComponent<Keychain>();
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && touch && heldKey != 0)
        {
            UpdatePickProgress(); 
        }
        else if (pickProgress >= 360 && heldKey != 0)
        {
            UpdatePickProgress();
        }
        else if(pickProgress < 360 && pickProgress != 0)
        {
            pickProgress = 0;
            if (textbox.enabled)
            {
                textbox.enabled = false;
                text.enabled = false;
            }
        }
        
    }

    void UpdatePickProgress()
    {
        if (!textbox.enabled)
        {
            textbox.enabled = true;
            text.enabled = true;
        }

        switch (pickProgress) {
            case 0:
                text.SetText("Pocketing<br>key...");
                break;
            case 45:
                text.SetText("Pocketing<br>key....");
                break;
            case 90:
                text.SetText("Pocketing<br>key.....");
                break;
            case 135:
                text.SetText("Pocketing<br>key......");
                break;
            case 180:
                text.SetText("Key get!");
                keychain.addKey();
                objectiveTracker.currentObjective.completeObjective(1);
                break;
            case 300:
                heldKey = 0;
                pickProgress = 0;
                break;
        }

        pickProgress++;
    }
}