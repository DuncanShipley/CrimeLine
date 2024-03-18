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
    private bool touch;

    // Start is called before the first frame update
    void Start()
    {
        textbox = GameObject.Find("playerTextbox").GetComponent<Image>();
        text = GameObject.Find("playerText").GetComponent<TextMeshProUGUI>();
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
        if (Input.GetKey(KeyCode.Space) && touch && heldKey != 0)
        {
            UpdatePickProgress();
            if(pickProgress == 360)
            {
                GetKey();
            }
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
        else if(pickProgress >= 360 && heldKey != 0)
        {
            UpdatePickProgress();
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
            case 90:
                text.SetText("Pocketing<br>key....");
                break;
            case 180:
                text.SetText("Pocketing<br>key.....");
                break;
            case 270:
                text.SetText("Pocketing<br>key......");
                break;
            case 360:
                text.SetText("Key get!");
                break;
            case 540:
                heldKey = 0;
                pickProgress = 0;
                break;
        }

        pickProgress++;
    }

    void GetKey()
    {
    }
}
