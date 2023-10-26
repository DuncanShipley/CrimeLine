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
            Cursor cursor = GameObject.Find("Cursor").GetComponent<Cursor>();
            cursor.listen();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                tiles[cursor.gridPos()].GetComponent<panelTileScript>().toggleState();
                if(cursor.cx - 1 > 0)
                {
                    tiles[cursor.gridPos() - 1].GetComponent<panelTileScript>().toggleState();
                }
                if (cursor.cx + 1 <= 2)
                {
                    tiles[cursor.gridPos() + 1].GetComponent<panelTileScript>().toggleState();
                }
                if (cursor.cy - 1 > 0)
                {
                    tiles[cursor.gridPos() - 3].GetComponent<panelTileScript>().toggleState();
                }
                if (cursor.cy + 1 <= 2)
                {
                    tiles[cursor.gridPos() + 3].GetComponent<panelTileScript>().toggleState();
                }
            }
            if (allOn())
            {
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
        GameObject.Find("Cursor").GetComponent<Cursor>().setup(1, 1, 2, 2, 30, 30);

        for (int i = 0; i < 9; i++)
        {
            GameObject puzzlesprite = GameObject.Instantiate(sc, container.transform);

            puzzlesprite.transform.position = new Vector3((i % 3 + 1) * 30 + 502, (i / 3 + 1) * 30 + 246, 0);
            puzzlesprite.name = "puzzlesprite" + i;

            tiles.Add(puzzlesprite);
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
            if(!tiles[i].GetComponent<panelTileScript>().getState())
            {
                return false;
            }
        }

        return true;
    }
}
