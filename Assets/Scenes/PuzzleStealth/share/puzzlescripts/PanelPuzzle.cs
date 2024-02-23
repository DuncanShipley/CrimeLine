using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelPuzzle : MonoBehaviour
{
    bool activated = false;
    public GameObject sc;
    public GameObject container;
    private List<GameObject> tiles = new List<GameObject>(9);
    int x = 1;
    int y = 1;

    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isActivated())
        {
            GameObject cursor = GameObject.Find("Cursor");
            if (Input.GetKeyDown(KeyCode.RightArrow) && cursor.transform.position.x <= 557)
            {
                cursor.transform.position = new Vector3(cursor.transform.position.x + 30, cursor.transform.position.y, cursor.transform.position.z);
                x++;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && cursor.transform.position.x >= 557)
            {
                cursor.transform.position = new Vector3(cursor.transform.position.x - 30, cursor.transform.position.y, cursor.transform.position.z);
                x--;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && cursor.transform.position.y <= 306)
            {
                cursor.transform.position = new Vector3(cursor.transform.position.x, cursor.transform.position.y + 30, cursor.transform.position.z);
                y++;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && cursor.transform.position.y >= 306)
            {
                cursor.transform.position = new Vector3(cursor.transform.position.x, cursor.transform.position.y - 30, cursor.transform.position.z);
                y--;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                tiles[y * 3 + x].GetComponent<panelTileScript>().toggleState();
                if(x - 1 >= 0)
                {
                    tiles[y * 3 + (x - 1)].GetComponent<panelTileScript>().toggleState();
                }
                if (x + 1 <= 2)
                {
                    tiles[y * 3 + (x + 1)].GetComponent<panelTileScript>().toggleState();
                }
                if (y - 1 >= 0)
                {
                    tiles[(y - 1) * 3 + x].GetComponent<panelTileScript>().toggleState();
                }
                if (y + 1 <= 2)
                {
                    tiles[(y + 1) * 3 + x].GetComponent<panelTileScript>().toggleState();
                }
            }
            if (allOn())
            {
                objectiveTracker.currentObjective.completeObjective(3);

                activated = false;
                GameObject.Find("Panel").GetComponent<Image>().enabled = false;
                GameObject.Find("Cursor").GetComponent<Image>().enabled = false;
                for (int i = 0; i < 9; i++)
                {
                    GameObject.Destroy(tiles[i]);
                }
            }
        }
    }

    public void activate()
    {
        activated = true;
        GameObject.Find("Panel").GetComponent<Image>().enabled = true;

        GameObject.Find("Cursor").GetComponent<Image>().enabled = true;
        GameObject.Find("Cursor").transform.position = new Vector3(557, 306, 0);

        for (int i = 0; i < 9; i++)
        {
            GameObject puzzlesprite = GameObject.Instantiate(sc, container.transform);

            puzzlesprite.transform.position = new Vector3((i % 3 + 1) * 30 + 497, (i / 3 + 1) * 30 + 246, 0);
            puzzlesprite.name = "puzzlesprite" + i;

            tiles.Add(puzzlesprite);
        }
    }
    public bool isActivated()
    {
        return activated;
    }
    public bool allOn()
    {
        for(int i = 0; i < 9; i++)
        {
            if(!tiles[i].GetComponent<panelTileScript>().getState())
            {
                return false;
            }
        }

        return true;
    }
}
