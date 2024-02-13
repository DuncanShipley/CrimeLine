using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
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
                pauseMenu.SetActive(true);
                menuActive = true;
                doNotGo = true;
            }
            if (menuActive && !doNotGo)
            {
                pauseMenu.SetActive(false);
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
