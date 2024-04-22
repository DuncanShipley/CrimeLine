using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radio : MonoBehaviour
{
    public GameObject guard;
    private bool placed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Guard")
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    public void deploy()
    {
        gameObject.SetActive(true);
        transform.position = GameObject.Find("Player").transform.position;
        placed = true;
    }
}
