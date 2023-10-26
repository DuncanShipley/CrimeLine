using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;
    public static int availible = 5;
    bool shot = false;
    bool landed = false;
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
        if (collision.tag == "Player" && shot)
        {
            availible++;
            Destroy(gameObject);
        }
        if (collision.gameObject.name != "proj" && collision.gameObject.tag != "Player" && !landed)
        {
            landed = true;
            rb.velocity = Vector3.zero;
            gameObject.transform.SetParent(collision.gameObject.transform);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
