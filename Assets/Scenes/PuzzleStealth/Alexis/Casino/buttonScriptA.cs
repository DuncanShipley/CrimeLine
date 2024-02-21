using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScriptA : MonoBehaviour
{
    public GameObject laser;
    public Sprite on;
    public Sprite off;
    private InputController input;
    bool touch = false;

    // Start is called before the first frame update
    void Start()
    {
        input = GameObject.Find("UI").GetComponent<InputController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.GetKeyLimited("z") && touch)
        {
            laser.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().sprite = off;
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
