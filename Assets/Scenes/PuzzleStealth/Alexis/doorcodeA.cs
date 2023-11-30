using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorcodeA : MonoBehaviour
{
    public int key;
    bool touch = false;
    bool open = true;
    float movequeue = 0;
    float speed = 10;

    // Colider
    private void start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player"){
            touch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        touch = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && touch && open && movequeue == 0)
        {
            keysA heldKeysScript = GameObject.Find("Player").GetComponent<keysA>();
            int heldKeys = heldKeysScript.getKeys();

            if (key == 0 || heldKeys >= key)
            {
                movequeue = 55;
                open = false;
            }
        }

        if (movequeue != 0)
        {
            var rb = GetComponent<Rigidbody2D>();
            var x = 0;
            var y = 0;

            if (gameObject.tag == "leftdoor")
                x = -1;
            if (gameObject.tag == "rightdoor")
                x = 1;

            Vector3 inp = new Vector3(x / speed, y / speed, 0);
            rb.MovePosition(transform.position + inp);
            movequeue--;
        }
    }
}
