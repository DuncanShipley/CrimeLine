using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaypointFollowerAlexis : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    public static GameObject[] wpref;
    //static public int currentWaypointIndex = 0;
    private float guardWait = 0f;
    int movingLeft;
    bool movingDown;
    //public static bool chase;
    public static float detectRadius = 75;
    //public int oldWaypointIndex;
    //public static float suspicious;
    public float leftDetectEdge;
    public float rightDetectEdge;
    public double relAngle;
    public float zrotation = 0;
    private bool seesPlayer;
    private float atan;

    public int id;

    public static List<int> currentPointIndex = new List<int>();
    public static List<float> sus = new List<float>();
    public static List<bool> chase = new List<bool>();
    public static List<bool> alerting = new List<bool>();
    public static List<bool> seeing = new List<bool>();
    public static List<int> oldPointIndex = new List<int>();


    [SerializeField] private float speed = 2f;
    public GameObject Player;

    public Rigidbody2D rb;

    RaycastHit2D seeingRay;

    Vector3 startingPosition;
    public void Start()
    {
        Player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();

        wpref = waypoints;
        movingLeft = 0;
        movingDown = false;

        currentPointIndex.Add(0);
        sus.Add(0);
        chase.Add(false);
        alerting.Add(false);
        seeing.Add(false);
        oldPointIndex.Add(0);
        startingPosition = transform.position;
    }

    private void Update()
    {
        
        id = gameObject.transform.parent.GetComponent<IDsAlexis>().GetID();
        Debug.Log(currentPointIndex[0]);

        seesPlayer = CheckFor(Player);

        if (guardHealthAlexis.aliveList[id])
        {
            if (Vector2.Distance(waypoints[currentPointIndex[id]].transform.position, transform.position) < .1f && guardWait <= 1 && !chase[id]) // if you're close and you haven't waited
            {
                guardWait += Time.deltaTime; // wait

            }
            else if (guardWait >= 1) // once you've waited (and are still close)
            {
                currentPointIndex[id]++; // look towards the next waypoint
                guardChaseAlexis.putWaypoint(startingPosition, id);
                if (currentPointIndex[id] >= waypoints.Length)
                {
                    currentPointIndex[id] = 0;
                }
                guardWait = 0; // reset wait timer
                if (true)
                {
                    transform.position = Vector2.MoveTowards(transform.position, waypoints[currentPointIndex[id]].transform.position, Time.deltaTime * speed);

                }
            }
            else if (sus[id] == 0 || sus[id] == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[currentPointIndex[id]].transform.position, Time.deltaTime * speed); // move towards waypoint
            }
            if ((float)(waypoints[currentPointIndex[id]].transform.position.x - transform.position.x) < 0f) // are moving left?
            {
                movingLeft = 180;
            }
            else
            {
                movingLeft = 0;
            }
            if ((float)(waypoints[currentPointIndex[id]].transform.position.y - transform.position.y) < 0f) // are moving down?
            {
                movingDown = true;
            }
            else
            {
                movingDown = false;

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
            if (Mathf.Abs(waypoints[currentPointIndex[id]].transform.position.x - transform.position.x) > 0.01f)
            {
                atan = (float)Math.Atan((waypoints[currentPointIndex[id]].transform.position.y - transform.position.y) / (waypoints[currentPointIndex[id]].transform.position.x - transform.position.x));
            }
            else if (Mathf.Abs(waypoints[currentPointIndex[id]].transform.position.x - transform.position.x) > 0)
            {
                atan = (float)Math.PI / 2;
            }
            else
            {
                atan = (float)-Math.PI / 2;
            }
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, (float)(atan * 180 / Math.PI) - 90 + movingLeft); // point towards current waypoint
            leftDetectEdge = transform.eulerAngles.z - 270 - detectRadius / 2;
            rightDetectEdge = transform.eulerAngles.z - 90 + detectRadius / 2;
            if (leftDetectEdge < -detectRadius / 2)
            {
                leftDetectEdge += 360;
            }
            if (rightDetectEdge < detectRadius / 2)
            {
                rightDetectEdge += 360;
            } // establish the radii within which the guard can detect the player
            if (Vector2.Distance(transform.position, Player.transform.position) < detectRadius / 7 && seesPlayer) // if the player is within the guard's light
            {
                if (sus[id] < 1) // and the guard isn't suspicious
                {
                    sus[id] = sus[id] + 10 * Time.deltaTime / Vector2.Distance(transform.position, Player.transform.position); // increase the guard's suspicion
                }
                else // if they are suspicious, begin chasing the player
                {
                    chase[id] = true;
                    AlertAlexis.alerted[id] = -1;
                    seeing[id] = true;
                    oldPointIndex[id] = currentPointIndex[id];
                    currentPointIndex[id] = 0;
                    detectRadius = 121;
                    speed = 6f;
                    sus[id] = 1;
                    alerting[id] = true;
                }
            }
            else if (AlertAlexis.alerted[id] > -1)
            {
                detectRadius = 121;
                speed = 6f;
                oldPointIndex[id] = currentPointIndex[id];
                currentPointIndex[id] = 0;
            }
            else if (sus[id] > 0) // if they're suspicious and the player isn't within their light, decrease their suspicion
            {
                sus[id] = sus[id] - 0.5f * Time.deltaTime;
                AlertAlexis.alerted[id] = -1;
                alerting[id] = false;
                seeing[id] = false;
            }
            else // if none of those are true, end the chase
            {
                chase[id] = false;
                detectRadius = 81;
                speed = 2f;
                sus[id] = 0;
                alerting[id] = false;
                seeing[id] = false;
            }
            zrotation = transform.eulerAngles.z;
        }
        else if (guardHealthAlexis.dyingList[id]) // plat our cute little death animation when the guard dies
        {
            zrotation += 360 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, zrotation);
        }
        else
        {
            rb.velocity /= 1.02f;
            rb.angularVelocity /= 1.02f;
        }
    }
    private bool CheckFor(GameObject cf)
    {
        for (float i = 0; i < 50; i++)
        {
            if (!movingDown && movingLeft != 180)
            {
                seeingRay = Physics2D.Raycast(transform.position, new Vector2((float)-Math.Sin((((50 - i) * (leftDetectEdge + 360) * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos((((50 - i) * (leftDetectEdge + 360) * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50)), (float)Math.Sqrt(detectRadius), Physics.DefaultRaycastLayers, -Mathf.Infinity, Mathf.Infinity);
            }
            else
            {
                seeingRay = Physics2D.Raycast(transform.position, new Vector2((float)-Math.Sin((((50 - i) * leftDetectEdge * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos((((50 - i) * leftDetectEdge * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50)), (float)Math.Sqrt(detectRadius), Physics.DefaultRaycastLayers, -Mathf.Infinity, Mathf.Infinity);
            }
            if (seeingRay.collider != null)
            {
                if (seeingRay.collider.gameObject == cf)
                {
                    guardChaseAlexis.putWaypoint(seeingRay.collider.gameObject.transform.position, id);
                    return true;
                }
            }
            if (!movingDown && movingLeft == 180)
            {
                seeingRay = Physics2D.Raycast(transform.position, new Vector2((float)-Math.Sin(((i * (rightDetectEdge - 360) * Math.PI / 180) + (50 - i) * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos(((i * (rightDetectEdge - 360) * Math.PI / 180) + (50 - i) * transform.rotation.eulerAngles.z * Math.PI / 180) / 50)), (float)Math.Sqrt(detectRadius), Physics.DefaultRaycastLayers, -Mathf.Infinity, Mathf.Infinity);
            }
            else
            {
                seeingRay = Physics2D.Raycast(transform.position, new Vector2((float)-Math.Sin(((i * rightDetectEdge * Math.PI / 180) + (50 - i) * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos(((i * rightDetectEdge * Math.PI / 180) + (50 - i) * transform.rotation.eulerAngles.z * Math.PI / 180) / 50)), (float)Math.Sqrt(detectRadius), Physics.DefaultRaycastLayers, -Mathf.Infinity, Mathf.Infinity);

            }
            if (seeingRay.collider != null)
            {
                if (seeingRay.collider.gameObject == cf)
                {
                    guardChaseAlexis.putWaypoint(seeingRay.collider.gameObject.transform.position, id);
                    return true;
                }
            }
        }
        return false;
    }
}




