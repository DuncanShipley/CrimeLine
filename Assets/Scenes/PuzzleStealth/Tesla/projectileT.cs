using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileT : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;
    public static int availible = 5;
    bool shot = false;
    // Start is called before the first frame update

    void Start()
    {
        gameObject.name = "proj";
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        shot = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "proj" && collision.gameObject.tag != "Player")
            rb.velocity = Vector3.zero;
        
        if (collision.tag == "Player" && shot)
        {
            availible++;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
