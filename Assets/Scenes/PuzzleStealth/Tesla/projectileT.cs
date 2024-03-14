using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileT : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;
    public static int availible = 5;
    bool shot = false;
    bool landed = false;
    GameObject copy;
    Vector3 lastInput;
    float h = 0f;
    float v = 0f;
    static float throwPause = 0;
    Renderer render;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        render = GetComponent<Renderer>();
        if (gameObject.name == "projectile") { render.enabled = false; }
    }

    void Update()
    {
        if (gameObject.name == "projectile")
        {
            transform.position = player.transform.position;
        }

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        // last movement
        if ((Mathf.Abs(h) > 0) || (Mathf.Abs(v) > 0)) // if it's moving
        {
            if (Mathf.Abs(h) > 0) // if it's moving horizontally record the horizontal movement
                lastInput.x = (h / Mathf.Abs(h)) * 100;
            else if (Mathf.Abs(v) - Mathf.Abs(h) > .1) // if its only moving horizontally a bit and it's moving vertically, ignore horizontal movement
                lastInput.x = 0;

            if (Mathf.Abs(v) > 0) // opposite as above
                lastInput.y = (v / Mathf.Abs(v)) * 100;
            else if (Mathf.Abs(h) - Mathf.Abs(v) > .1)
                lastInput.y = 0;
        }

        throwPause += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E) && availible > 0 && throwPause >= 2)
        {
            //availible--;
            copy = Instantiate(gameObject, player.transform.position, new Quaternion()); // create a projectile at the player's location
            copy.name = "proj";
            copy.GetComponent<Renderer>().enabled = true;

            if (lastInput.x == 100)
            {
                if (lastInput.y == 100) // up right
                {
                    copy.transform.Rotate(0, 0, 315);
                }
                else if (lastInput.y == 0) // right
                {
                    copy.transform.Rotate(0, 0, 270);
                }
                else if (lastInput.y == -100) // down right
                {
                    copy.transform.Rotate(0, 0, 225);
                }
            }
            else if (lastInput.x == 0)
            {
                if (lastInput.y == 100) // up
                {
                    copy.transform.Rotate(0, 0, 0);
                }
                else if (lastInput.y == -100) // down
                {
                    copy.transform.Rotate(0, 0, 180);
                }
            }
            else if (lastInput.x == -100)
            {
                if (lastInput.y == 100) // up left
                {
                    copy.transform.Rotate(0, 0, 45);
                }
                else if (lastInput.y == 0) // left
                {
                    copy.transform.Rotate(0, 0, 90);
                }
                else if (lastInput.y == -100) // down left
                {
                    copy.transform.Rotate(0, 0, 135);
                }
            }

            throwPause = 0;
            var pRB = copy.GetComponent<Rigidbody2D>();
            pRB.AddRelativeForce(lastInput); // move in the same direction as last player movement

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") { shot = true; } // when it stops touching the player
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && shot && gameObject.name == "proj")
        {
            availible++;
            Destroy(gameObject);
        } // if the player touches it after the initial shot, pick it up
        if (collision.gameObject.name != "proj" && collision.gameObject.name != "projectile" && collision.gameObject.tag != "Player" && collision.gameObject.tag != "GuardSensor" && !landed && gameObject.name == "proj")//collision.gameObject.tag == "Guard") 
        {
            landed = true;
            rb.velocity = Vector3.zero;
            gameObject.transform.SetParent(collision.gameObject.transform);
        } // stop and stick if not another projectile, not the player, not the sensor range for the guard, it's already been shot, and its not the base
    }
    // Update is called once per frame
}
