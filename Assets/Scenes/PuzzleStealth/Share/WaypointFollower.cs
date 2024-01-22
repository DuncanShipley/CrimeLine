using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    public static GameObject[] wpref;
    //static public int currentWaypointIndex = 0;
    private float guardWait = 0f;
    int movingLeft;
    //public static bool chase;
    public static float detectRadius = 75;
    public int oldWaypointIndex;
    //public static float suspicious;
    public float leftDetectEdge;
    public float rightDetectEdge;
    public double relAngle;
    
    public int id;

    public static List<int> currentPointIndex = new List<int>();
    public static List<float> sus = new List<float>();
    public static List<bool> chase = new List<bool>();
    public static List<bool> alerting = new List<bool>();
    public static List<bool> seeing = new List<bool>();


    [SerializeField] private float speed = 2f;
    public GameObject Player;
    public void Start()
    {
        Player = GameObject.Find("Player");

        wpref = waypoints;
        movingLeft = 0;

        currentPointIndex.Add(0);
        sus.Add(0);
        chase.Add(false);
        alerting.Add(false);
        seeing.Add(false);
    }

    private void Update()
    {
        id = gameObject.transform.parent.GetComponent<IDsT>().GetID();

        if (guardHealth.aliveList[id])
        {
            if (Vector2.Distance(waypoints[currentPointIndex[id]].transform.position, transform.position) < .1f && guardWait <= 1 && !chase[id]) // if you're close and you haven't waited
            {
                guardWait = guardWait + Time.deltaTime; // wait

            }
            else if (guardWait >= 1) // once you've waited (and are still close)
            {
                currentPointIndex[id]++; // look towards the next waypoint
                if (currentPointIndex[id] >= waypoints.Length)
                {
                    currentPointIndex[id] = 0;
                }
                guardWait = 0; // reset wait timer
                if (sus[id] == 0 || sus[id] == 1)
                {
                    transform.position = Vector2.MoveTowards(transform.position, waypoints[currentPointIndex[id]].transform.position, Time.deltaTime * speed);

                }
            }
            else if (sus[id] == 0 || sus[id] == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[currentPointIndex[id]].transform.position, Time.deltaTime * speed); // move towards waypoint
            }
            if ((float)(wpref[currentPointIndex[id]].transform.position.x - transform.position.x) < 0f) // are moving left?
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
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, (float)(Math.Atan((wpref[currentPointIndex[id]].transform.position.y - transform.position.y) / (wpref[currentPointIndex[id]].transform.position.x - transform.position.x)) * 180 / Math.PI) - 90 + movingLeft); // point towards current waypoint
            leftDetectEdge = transform.eulerAngles.z - 270 - detectRadius / 2;
            rightDetectEdge = transform.eulerAngles.z - 270 + detectRadius / 2;
            if (leftDetectEdge < -detectRadius / 2)
            {
                leftDetectEdge = leftDetectEdge + 360;
            }
            if (rightDetectEdge < detectRadius / 2)
            {
                rightDetectEdge = rightDetectEdge + 360;
            } // establish the radii within which the guard can detect the player
            if (Vector2.Distance(transform.position, Player.transform.position) < Math.Sqrt(detectRadius) && leftDetectEdge < relAngle && relAngle < rightDetectEdge) // if the player is within the guard's light
            {
                if (sus[id] < 1) // and the guard isn't suspicious
                {
                    sus[id] = sus[id] + 10 * Time.deltaTime / Vector2.Distance(transform.position, Player.transform.position); // increase the guard's suspicion
                }
                else // if they are suspicious, begin chasing the player
                {
                    chase[id] = true;
                    Alert.alerted[id] = -1;
                    seeing[id] = true;
                    oldWaypointIndex = currentPointIndex[id];
                    currentPointIndex[id] = 0;
                    detectRadius = 121;
                    speed = 6f;
                    sus[id] = 1;
                }
            }
            else if (Alert.alerted[id] > -1)
            {
                detectRadius = 121;
                speed = 6f;
                oldWaypointIndex = currentPointIndex[id];
                currentPointIndex[id] = 0;
            }
            else if (sus[id] > 0) // if they're suspicious and the player isn't within their light, decrease their suspicion
            {
                sus[id] = sus[id] - 0.5f * Time.deltaTime;
                Alert.alerted[id] = -1;
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
        }
    }
}
