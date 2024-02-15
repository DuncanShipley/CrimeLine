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
    GameObject copy;
    Vector3 lastInput;
    float h = 0f;
    float v = 0f;
    static float throwPause = 0;
    float rotationGoal;
    // Start is called before the first frame update

    void Start()
    {
        gameObject.name = "proj";
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    void Update()
    {


        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        // last movement
        if ((Mathf.Abs(h) > 0) || (Mathf.Abs(v) > 0)) // if it's moving
        {
            if (Mathf.Abs(h) > 0) // if it's moving horizontally record the horizontal movement
                lastInput.x = (h / Mathf.Abs(h)) * 100;
            else if (Mathf.Abs(v) - Mathf.Abs(h) > .1) // if its only moving horizontally a bit and it's moving vertically, ignore horizontal movement
                lastInput.x = 0;

            if (Mathf.Abs(v) > 0)
                lastInput.y = (v / Mathf.Abs(v)) * 100;
            else if (Mathf.Abs(h) - Mathf.Abs(v) > .1)
                lastInput.y = 0;
        }

        rotationGoal = Mathf.Atan(lastInput.x / lastInput.y);
        throwPause += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E) && availible > 0 && throwPause >= 2)
        {
            availible--;
            //copy = Instantiate(gameObject, player.transform.position, new Quaternion(0, 0, rotationGoal, 0)); // create a projectile at the player's location
            copy = Instantiate(gameObject, player.transform.position, new Quaternion()); // create a projectile at the player's location
            //Debug.Log(rotationGoal);
            throwPause = 0;
            var pRB = copy.GetComponent<Rigidbody2D>();
            //pRB.AddRelativeForce(Vector3.up * 100); // move in the same direction as last player movement
            pRB.AddRelativeForce(lastInput); // move in the same direction as last player movement
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        shot = true; // when it stops touching the player
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && shot)
        {
            availible++;
            Destroy(gameObject);
        } // if the player touches it after the initial shot, pick it up
        if (collision.gameObject.name != "proj" && collision.gameObject.tag != "Player" && collision.gameObject.tag != "GuardSensor" && !landed)
        {
            landed = true;
            rb.velocity = Vector3.zero;
            gameObject.transform.SetParent(collision.gameObject.transform);
        } // if it hits something real, stop moving and attatch to the item it hit
    }
    // Update is called once per frame
}
