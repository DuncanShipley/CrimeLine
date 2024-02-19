using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    [SerializeField] private GameObject escapeMenu;
    bool menuActive = false;
    bool doNotGo = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menuActive && !doNotGo)
            {
                escapeMenu.SetActive(true);
                Debug.Log("Menu Active");
                menuActive = true;
                doNotGo = true;
            }
            if (menuActive && !doNotGo)
            {
                escapeMenu.SetActive(false);
                Debug.Log("Menu Inactive");
                menuActive = false;
                doNotGo = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            doNotGo = false;
        }
    }
}
