using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollowerBK : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    public static GameObject[] wpref;
    static public int currentWaypointIndex = 0;
    private float guardWait = 0f;
    int movingLeft;
    public static bool chase;
    public static float detectRadius = 75;
    public int oldWaypointIndex;
    public static float suspicious;
    public float leftDetectEdge;
    public float rightDetectEdge;
    public double relAngle;
    public float zrotation = 0;
    private bool seesPlayer;
    private float atan;

    [SerializeField] private float speed = 2f;
    public GameObject Player;

    public Rigidbody2D rb;

    RaycastHit2D seeing;
    public void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        wpref = waypoints;
        movingLeft = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        seesPlayer = CheckFor(Player);
        if (guardHealthBK.alive && !guardHealthBK.dying)
        {
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f && guardWait <= 1 && !chase) // if you're close and you haven't waited
            {
                guardWait = guardWait + Time.deltaTime; // wait

            }
            else if (guardWait >= 1) // once you've waited (and are still close)
            {
                currentWaypointIndex++; // look towards the next waypoint
                guardChaseBK.resetWaypoints();
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
                guardWait = 0; // reset wait timer
                if (suspicious == 0 || suspicious == 1)
                {
                    transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);

                }
            }
            else if (suspicious == 0 || suspicious == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed); // move towards waypoint
            }
            if ((float)(wpref[currentWaypointIndex].transform.position.x - transform.position.x) < 0f) // are moving left?
            {
                movingLeft = 180;
            }
            else
            {
                movingLeft = 0;
            }
            if (Player.transform.position.y > transform.position.y && Player.transform.position.x > transform.position.x) // if the player is up and to the right of us
            {
                relAngle = Math.Atan((Player.transform.position.y - transform.position.y) / (Player.transform.position.x - transform.position.x)) * 180 / Math.PI;
            }
            else if (Player.transform.position.x < transform.position.x) // if they're to the left of us
            {
                relAngle = Math.Atan((Player.transform.position.y - transform.position.y) / (Player.transform.position.x - transform.position.x)) * 180 / Math.PI + 180;
            }
            else // if they're down and to the right of us
            {
                relAngle = Math.Atan((Player.transform.position.y - transform.position.y) / (Player.transform.position.x - transform.position.x)) * 180 / Math.PI + 360;
            }
            // ^^ these are to take the inverse tangent of the correct 'triangle' ^^
            if (Mathf.Abs(wpref[currentWaypointIndex].transform.position.x - transform.position.x) > 0.01f)
            {
                atan = (float)Math.Atan((wpref[currentWaypointIndex].transform.position.y - transform.position.y) / (wpref[currentWaypointIndex].transform.position.x - transform.position.x));
            }
            else if (Mathf.Abs(wpref[currentWaypointIndex].transform.position.x - transform.position.x) > 0)
            {
                atan = (float)Math.PI / 2;
            }
            else
            {
                atan = (float)-Math.PI / 2;
            }
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, (float)(atan * 180 / Math.PI) - 90 + movingLeft); // point towards current waypoint
            leftDetectEdge = transform.eulerAngles.z + (suspicious * 22.5f + 37.5f);
            rightDetectEdge = transform.eulerAngles.z - (suspicious * 22.5f + 37.5f);
            if (leftDetectEdge < -detectRadius / 2)
            {
                leftDetectEdge = leftDetectEdge + 360;
            }
            if (rightDetectEdge < detectRadius / 2)
            {
                rightDetectEdge = rightDetectEdge + 360;
            } // establish the radii within which the guard can detect the player
            if (Vector2.Distance(transform.position, Player.transform.position) < detectRadius / 7 && seesPlayer) // if the player is within the guard's light
            {
                if (suspicious < 1) // and the guard isn't suspicious
                {
                    suspicious = suspicious + 10 * Time.deltaTime / Vector2.Distance(transform.position, Player.transform.position); // increase the guard's suspicion
                }
                else // if they are suspicious, begin chasing the player
                {
                    chase = true;
                    oldWaypointIndex = currentWaypointIndex;
                    currentWaypointIndex = 0;
                    detectRadius = 121;
                    speed = 6f;
                    suspicious = 1;
                }
            }
            else if (suspicious > 0) // if they're suspicious and the player isn't within their light, decrease their suspicion
            {
                suspicious = suspicious - 0.5f * Time.deltaTime;
            }
            else // if none of those are true, end the chase
            {
                chase = false;
                detectRadius = 81;
                speed = 2f;
                suspicious = 0;
            }
            zrotation = transform.eulerAngles.z;
        }
        else if (guardHealthBK.dying) // plat our cute little death animation when the guard dies
        {
            zrotation = zrotation + 360 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, zrotation);
        }
        else
        {
            rb.velocity = rb.velocity / 1.02f;
            rb.angularVelocity = rb.angularVelocity / 1.02f;
        }
    }

    private bool CheckFor(GameObject cf)
    {
        for (int i = 0; i < 50; i++)
        {
            seeing = Physics2D.Raycast(transform.position, new Vector3((float)-Math.Sin((((50 - i) * leftDetectEdge * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos((((50 - i) * leftDetectEdge * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), 0), (float)Math.Sqrt(detectRadius), Physics.DefaultRaycastLayers, -Mathf.Infinity, Mathf.Infinity);
            if (seeing.collider != null)
            {
                if (seeing.collider.gameObject == cf)
                {
                    guardChaseBK.putWaypoint(seeing.collider.gameObject.transform.position);
                    return true;
                }
            }
            if (movingLeft == 180)
            {
                seeing = Physics2D.Raycast(transform.position, new Vector3((float)-Math.Sin(((i * rightDetectEdge * Math.PI / 180) + (50 - i) * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos(((i * rightDetectEdge * Math.PI / 180) + (50 - i) * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), 0), (float)Math.Sqrt(detectRadius), Physics.DefaultRaycastLayers, -Mathf.Infinity, Mathf.Infinity);
            }
            else
            {
                seeing = Physics2D.Raycast(transform.position, new Vector3((float)-Math.Sin((((50 - i) * rightDetectEdge * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos((((50 - i) * rightDetectEdge * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), 0), (float)Math.Sqrt(detectRadius), Physics.DefaultRaycastLayers, -Mathf.Infinity, Mathf.Infinity);
            }
            if (seeing.collider != null)
            {
                if (seeing.collider.gameObject == cf)
                {
                    guardChaseBK.putWaypoint(seeing.collider.gameObject.transform.position);
                    return true;
                }
            }
        }
        return false;
    }
}


