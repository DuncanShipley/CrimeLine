using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardShootT : MonoBehaviour
{
    bool shot = false;
    GameObject copy;
    float throwPause = 0;
    public int id;
    public GameObject guardProjectile;

    // Start is called before the first frame update

    void Start()
    {
    }

    void Update()
    {/*

        id = gameObject.transform.parent.GetComponent<IDsT>().GetID();


        throwPause += Time.deltaTime;

        if (WaypointFollowerT.chase[id] && throwPause>.5)
        {
            Debug.Log("shoot");
            copy = Instantiate(guardProjectile, transform.position,guardProjectile.transform.rotation); // create a projectile at the player's location
            throwPause = 0;
            var pRB = copy.GetComponent<Rigidbody2D>();
            pRB.AddRelativeForce(Vector3.up); // move in the same direction as last player movement
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Guard")
        {
            shot = true; // when it stops touching the guard
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (shot)
        {
            Destroy(gameObject); // vanish when it hits something
        }
        */
    }
}
