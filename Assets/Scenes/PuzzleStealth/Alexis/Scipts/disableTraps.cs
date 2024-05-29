using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableTrap : MonoBehaviour
{
    private bool touch;
    private bool done;
    private GameObject[] lasers;

    // Start is called before the first frame update
    void Start()
    {
        lasers = GameObject.FindGameObjectsWithTag("laser");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && touch && !done)
        {
            for(int i = 0; i < lasers.Length; i++)
            {
                lasers[i].SetActive(false);
            }
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
