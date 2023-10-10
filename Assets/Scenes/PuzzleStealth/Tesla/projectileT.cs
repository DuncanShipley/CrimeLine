using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileT : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;
    public static int availible = 5;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector3.zero;
        
        if (collision.collider.tag == "Player")
        {
            Debug.Log("hit");
            availible++;
            //Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
