using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableTraps : MonoBehaviour
{
    private bool touch;
    private bool done = false;
    private GameObject[] guards;
    private GameObject[] lasers;

    // Start is called before the first frame update
    void Start()
    {
        lasers = GameObject.FindGameObjectsWithTag("laser");
        guards = GameObject.FindGameObjectsWithTag("Guard");
        for(int i = 0; i < guards.Length; i++)
            {
                guards[i].SetActive(false);
            }

            for(int i = 0; i < lasers.Length; i++)
            {
                lasers[i].SetActive(false);
            }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && touch && !done)
        {
            Debug.Log(guards.Length);
            for(int i = 0; i < guards.Length; i++)
            {
                guards[i].SetActive(true);
            }

            for(int i = 0; i < lasers.Length; i++)
            {
                lasers[i].SetActive(true);
            }
            done = true;
        }
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
}
