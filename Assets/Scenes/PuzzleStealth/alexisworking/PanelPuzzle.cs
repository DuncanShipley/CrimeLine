using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelPuzzle : MonoBehaviour
{
    bool activated = false;
    public GameObject sc;
    public GameObject container;
    int x;
    int y;

    // Start is called before the first frame update
    public void Start()
    {
        GameObject.Find("Panel").GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("keycardSprite").GetComponent<Image>().enabled = true;
    }

    public void activate()
    {
        activated = true;
        GameObject.Find("Panel").GetComponent<Image>().enabled = true;

        for(int i = 0; i < 9; i++)
        {
            GameObject puzzlesprite = GameObject.Instantiate(sc, container.transform);

            puzzlesprite.transform.position = new Vector3((i % 3 + 1) * 30 + 400, (i / 3 + 1) * 30 + 250, 0);
            puzzlesprite.name = "puzzlesprite" + i;
        }
    }

    public bool isActivated()
    {
        return activated;
    }
}
