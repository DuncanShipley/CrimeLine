using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pickpocketingBK : MonoBehaviour
{
    public int heldKey;

    private int pickProgress = 0;
    private Image textbox;
    private TextMeshProUGUI text;
    private KeychainBK keychain;
    private bool touch;

    // Start is called before the first frame update
    void Start()
    {
        textbox = GameObject.Find("playerTextbox").GetComponent<Image>();
        text = GameObject.Find("playerText").GetComponent<TextMeshProUGUI>();
        keychain = GameObject.Find("Player").GetComponent<KeychainBK>();
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
        if (Input.GetKey(KeyCode.Z) && touch)
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

        if(heldKey != 0)
        {
            switch (pickProgress)
            {
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
                    objectiveTrackerBK.currentObjective.completeObjective(1);
                    break;
                case 240:
                    heldKey = 0;
                    pickProgress = 0;
                    break;
            }

            pickProgress++;
        }
        else
        {
            text.SetText("Nothing to steal...");
        }
    }
}
