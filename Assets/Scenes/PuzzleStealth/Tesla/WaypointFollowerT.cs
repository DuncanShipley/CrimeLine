using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaypointFollowerT : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    public GameObject[] wpref;
    float guardWait = 0f;
    int movingLeft;
    float detectRadius = 75;
    public int oldWaypointIndex;
    public float leftDetectEdge;
    public float rightDetectEdge;
    public double relAngle;

    public int id;

    public static List<int> currentPointIndexList = new List<int>();
    public static List<float> susList = new List<float>();
    public static List<bool> chaseList = new List<bool>();


    [SerializeField] private float speed = 2f;
    public GameObject Player;
    public void Start()
    {
        Player = GameObject.Find("Player");

        wpref = waypoints;
        movingLeft = 0;


        currentPointIndexList.Add(0);
        susList.Add(0);
        chaseList.Add(false);


    }


    private void Update()
    {

        id = gameObject.transform.parent.GetComponent<IDsT>().GetID();

        if (guardHealthT.alive)
        {

            if (Vector2.Distance(waypoints[currentPointIndexList[id]].transform.position, transform.position) < .1f && guardWait <= 1 && !chaseList[id]) // if you're close and you haven't waited
            {
                guardWait = guardWait + Time.deltaTime; // wait

            }
            else if (guardWait >= 1) // once you've waited (and are still close)
            {
                currentPointIndexList[id]++; // look towards the next waypoint
                if (currentPointIndexList[id] >= waypoints.Length)
                {
                    currentPointIndexList[id] = 0;
                }
                guardWait = 0; // reset wait timer
                if (susList[id] == 0 || susList[id] == 1)
                {
                    transform.position = Vector2.MoveTowards(transform.position, waypoints[currentPointIndexList[id]].transform.position, Time.deltaTime * speed);

                }
            }
            else if (susList[id] == 0 || susList[id] == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[currentPointIndexList[id]].transform.position, Time.deltaTime * speed); // move towards waypoint
            }
            if ((float)(wpref[currentPointIndexList[id]].transform.position.x - transform.position.x) < 0f) // are moving left?
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
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, (float)(Math.Atan((wpref[currentPointIndexList[id]].transform.position.y - transform.position.y) / (wpref[currentPointIndexList[id]].transform.position.x - transform.position.x)) * 180 / Math.PI) - 90 + movingLeft); // point towards current waypoint
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
                if (susList[id] < 1) // and the guard isn't suspicious
                {
                    susList[id] = susList[id] + 10 * Time.deltaTime / Vector2.Distance(transform.position, Player.transform.position); // increase the guard's suspicion
                }
                else // if they are suspicious, begin chasing the player
                {
                    chaseList[id] = true;
                    oldWaypointIndex = currentPointIndexList[id];
                    currentPointIndexList[id] = 0;
                    detectRadius = 121;
                    speed = 6f;
                    susList[id] = 1;
                }
            }
            else if (susList[id] > 0) // if they're suspicious and the player isn't within their light, decrease their suspicion
            {
                susList[id] = susList[id] - 0.5f * Time.deltaTime;
            }
            else // if none of those are true, end the chase
            {
                chaseList[id] = false;
                detectRadius = 81;
                speed = 2f;
                susList[id] = 0;
            }
        }
    }
}
