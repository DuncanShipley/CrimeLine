using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCursorPos : MonoBehaviour
{
    public GameObject[] buttons;

    public Animator carSpin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 mousePos = Input.mousePosition;

        for(int i = 0; i < buttons.Length; i++)
        {
            float x = buttons[i].transform.position.x;
            float y = buttons[i].transform.position.y;
            float height = buttons[i].GetComponent<RectTransform>().rect.height;
            float length = buttons[i].GetComponent<RectTransform>().rect.width;

            float cx = mousePos.x;
            float cy = mousePos.y;
    

            if((cx >= x && cx <= x + length) && (cy >= y && cy <= y + height) && (i == 1))
            {
                carSpin.SetBool("ButtonHighlight", true);
            }
            else if (i == 1)
            {
                carSpin.SetBool("ButtonHighlight", false);
            }
        }
    }
}
