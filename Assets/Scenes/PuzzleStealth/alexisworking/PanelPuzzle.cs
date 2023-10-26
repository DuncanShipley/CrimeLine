using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzlescript : MonoBehaviour
{
    // PUBLIC VARS
    public GameObject pfInteracts ;  // Sets the prefab to use for interactables
    public GameObject container;    // Sets the container for any created objects

    // PRIVATE VARS

    // General
    private bool activated = false; // Is puzzle activated? Default false
    private List<GameObject> interacts = new List<GameObject>(); // Interactable objects. All must be "on" to complete the

    // REFRENCES
    Cursor cursor;

    void Start()
    {
        cursor = GameObject.Find("Cursor").GetComponent<Cursor>();
    }
    void Update()
    {
        if(activated)
        {
            cursor.listen();
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                int gridPos = cursor.gridPos();

                interacts[cursor.gridPos()].GetComponent<panelTileScript>().toggleState();
                if(cursor.cx - 1 >= 0)
                {
                    interacts[cursor.gridPos() - 1].GetComponent<panelTileScript>().toggleState();
                }
                if (cursor.cx + 1 <= 2)
                {
                    interacts[cursor.gridPos() + 1].GetComponent<panelTileScript>().toggleState();
                }
                if (cursor.cy - 1 >= 0)
                {
                    interacts[cursor.gridPos() - 3].GetComponent<panelTileScript>().toggleState();
                }
                if (cursor.cy + 1 <= 2)
                {
                    interacts[cursor.gridPos() + 3].GetComponent<panelTileScript>().toggleState();
                }
            }
            

            if (allOn())
            {
                activated = false;
                GameObject.Find("Panel").GetComponent<Image>().enabled = false;
                GameObject.Find("Cursor").GetComponent<Image>().enabled = false;
                for (int i = 0; i < 9; i++)
                {
                    GameObject.Destroy(interacts[i]);
                }
            }
        }
    }

    public void activate()
    {
        activated = true;
        GameObject.Find("Panel").GetComponent<Image>().enabled = true;

        cursor.setup(562, 306, 2, 2, 30, 30);

        for (int i = 0; i < 9; i++)
        {
            GameObject puzzlesprite = GameObject.Instantiate(pfInteracts, container.transform);

            puzzlesprite.transform.position = new Vector3((i % 3 + 1) * 30 + 502, (i / 3 + 1) * 30 + 246, 0);
            puzzlesprite.name = "puzzlesprite" + i;

            interacts.Add(puzzlesprite);
        }
        Debug.Log("hi");
    }
    public bool isActivated()
    {
        return activated;
    }

    public bool allOn()
    {
        for(int i = 0; i < 9; i++)
        {
            if(!interacts[i].GetComponent<panelTileScript>().getState())
            {
                return false;
            }
        }

        return true;
    }
}
