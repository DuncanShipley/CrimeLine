using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class guardInteracterBK : MonoBehaviour
{
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
        if (other.tag == "Guard")
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
        if (touch && !Input.GetKey(KeyCode.Z))
        {
            if (!textbox.enabled)
            {
                textbox.enabled = true;
                text.enabled = true;
            }
            text.SetText("[z] Steal<br>[x] Grab");
        }
        else if (!Input.GetKey(KeyCode.Z))
        {
            if (textbox.enabled)
            {
                textbox.enabled = false;
                text.enabled = false;
            }
        }
    }
}
