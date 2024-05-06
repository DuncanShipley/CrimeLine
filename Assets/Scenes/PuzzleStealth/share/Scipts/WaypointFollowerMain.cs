using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaypointFollowerMain : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    public GameObject Waypoint1;
    public static GameObject[] wpref;
    private float guardWait = 0f;
    public double relAngle;
    private float atan;
    public bool canMove = true;
    public float distance;

    public int id;

    public static List<int> currentPointIndex = new List<int>();
    public static List<int> movingLeft = new List<int>();
    public static List<bool> lookingLeft = new List<bool>();
    public static List<bool> movingDown = new List<bool>();
    public static List<bool> lookingDown = new List<bool>();
    public static List<bool> movedDown = new List<bool>();
    public static List<bool> close = new List<bool>();


    [SerializeField] public static List<float> speed = new List<float>();
    public float test = 0;

    public static List<float> testList = new List<float>();
    public GameObject Player;
    [SerializeField] Transform playerTrans;
    UnityEngine.AI.NavMeshAgent guard;

    public Rigidbody2D rb;

    RaycastHit2D seeingRay;

    Vector3 startingPosition;

    public void Start()
    {
        Player = GameObject.Find("Player");
        Waypoint1 = GameObject.Find("Waypoint 1");
        rb = GetComponent<Rigidbody2D>();

        wpref = waypoints;

        movingLeft.Add(0);
        lookingLeft.Add(false);
        movingDown.Add(false);
        lookingDown.Add(false);
        movedDown.Add(false);
        close.Add(false);

        currentPointIndex.Add(0);
        speed.Add(0);
        testList.Add(0);
        startingPosition = transform.position;

        guard = GetComponent<UnityEngine.AI.NavMeshAgent>();
        guard.updateRotation = false;
        guard.updateUpAxis = false;
    }

    private void Update()
    {
        id = gameObject.transform.parent.GetComponent<IDsMain>().GetID();

        testList[id] = test;
        if (canMove)
        {
            
            if (Vector2.Distance(waypoints[currentPointIndex[id]].transform.position, transform.position) < 1f && guardWait < 2f) // if you're close and you haven't waited
            {
                guardWait += Time.deltaTime; // wait
                close[id] = true;
            }
            else if (guardWait >= 2f) // once you've waited (and are still close)
            {
                currentPointIndex[id]++; // look towards the next waypoint
                guardChaseMain.putWaypoint(startingPosition, id, Waypoint1, false);
                if (currentPointIndex[id] >= waypoints.Length)
                {
                    currentPointIndex[id] = 0;
                }
                guardWait = 0; // reset wait timer
                close[id] = false;
            }
            else if (guardChaseMain.sus[id] == 0 || guardChaseMain.sus[id] == 1)
            {
                guard.SetDestination(waypoints[currentPointIndex[id]].transform.position); // move towards waypoint
                close[id] = false;
            }
            else{
                close[id] = false;
            }
            if (relAngle > 90 && relAngle < 270)
            {
                lookingLeft[id] = true;
            }
            else
            {
                lookingLeft[id] = false;
            }
            if (relAngle > 180)
            {
                lookingDown[id] = true;
            }
            else
            {
                lookingDown[id] = false;
            }
            if (close[id]) {
                if ((float)(waypoints[(currentPointIndex[id]+1) % 4].transform.position.x - transform.position.x) < 0f) // are moving left?
                {
                    movingLeft[id] = 180;
                }
                else
                {
                    movingLeft[id] = 0;
                }
                if ((float)(waypoints[(currentPointIndex[id]+1) % 4].transform.position.y - transform.position.y) < 0f) // are moving down?
                {
                    movingDown[id] = true;
                }
                else
                {
                    movingDown[id] = false;
                }
                if ((float)(waypoints[currentPointIndex[id]].transform.position.y - transform.position.y) < 0f) // are moving down?
                {
                    movedDown[id] = true;
                }
                else
                {
                    movedDown[id] = false;
                }
            }
            else{
                if ((float)(waypoints[currentPointIndex[id]].transform.position.x - transform.position.x) < 0f) // are moving left?
                {
                    movingLeft[id] = 180;
                }
                else
                {
                    movingLeft[id] = 0;
                }
                if ((float)(waypoints[currentPointIndex[id]].transform.position.y - transform.position.y) < 0f) // are moving down?
                {
                    movingDown[id] = true;
                }
                else
                {
                    movingDown[id] = false;
                }
            }
            if (close[id]){
                if (waypoints[(currentPointIndex[id]+1) % 4].transform.position.y > transform.position.y && waypoints[(currentPointIndex[id]+1) % 4].transform.position.x > transform.position.x) // if the next waypoint is up and to the right of us
                {
                    relAngle = Math.Atan((waypoints[(currentPointIndex[id]+1) % 4].transform.position.y - transform.position.y) / (waypoints[(currentPointIndex[id]+1) % 4].transform.position.x - transform.position.x)) * 180 / Math.PI + guardWait * 180;
                }
                else if (waypoints[(currentPointIndex[id]+1) % 4].transform.position.x < transform.position.x) // if it's to the left of us
                {
                    relAngle = Math.Atan((waypoints[(currentPointIndex[id]+1) % 4].transform.position.y - transform.position.y) / (waypoints[(currentPointIndex[id]+1) % 4].transform.position.x - transform.position.x)) * 180 / Math.PI + 180 + guardWait * 180;
                }
                else // if it's down and to the right of us
                {
                    relAngle = Math.Atan((waypoints[(currentPointIndex[id]+1) % 4].transform.position.y - transform.position.y) / (waypoints[(currentPointIndex[id]+1) % 4].transform.position.x - transform.position.x)) * 180 / Math.PI + 360 + guardWait * 180;
                }
                // ^^ these are to take the inverse tangent of the correct 'triangle' ^^
                if (Mathf.Abs(waypoints[(currentPointIndex[id]+1) % 4].transform.position.x - transform.position.x) > 0.01f)
                {
                    atan = (float)Math.Atan((waypoints[(currentPointIndex[id]+1) % 4].transform.position.y - transform.position.y) / (waypoints[(currentPointIndex[id]+1) % 4].transform.position.x - transform.position.x));
                }
                else if (Mathf.Abs(waypoints[(currentPointIndex[id]+1) % 4].transform.position.x - transform.position.x) > 0)
                {
                    atan = (float)Math.PI / 2;
                }
                else
                {
                    atan = (float)-Math.PI / 2;
                }
                relAngle = relAngle % 360;
            }
            else{
                if (waypoints[currentPointIndex[id]].transform.position.y > transform.position.y && waypoints[currentPointIndex[id]].transform.position.x > transform.position.x) // if the current waypoint is up and to the right of us
                {
                    relAngle = Math.Atan((waypoints[currentPointIndex[id]].transform.position.y - transform.position.y) / (waypoints[currentPointIndex[id]].transform.position.x - transform.position.x)) * 180 / Math.PI;
                }
                else if (waypoints[currentPointIndex[id]].transform.position.x < transform.position.x) // if it's to the left of us
                {
                    relAngle = Math.Atan((waypoints[currentPointIndex[id]].transform.position.y - transform.position.y) / (waypoints[currentPointIndex[id]].transform.position.x - transform.position.x)) * 180 / Math.PI;
                }
                else // if it's down and to the right of us
                {
                    relAngle = Math.Atan((waypoints[currentPointIndex[id]].transform.position.y - transform.position.y) / (waypoints[currentPointIndex[id]].transform.position.x - transform.position.x)) * 180 / Math.PI + 360;
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
            }
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, ((float)(relAngle) - 90 + movingLeft[id]) % 360); // point towards current waypoint
        }
        else
        {
            rb.velocity /= 1.02f;
            rb.angularVelocity /= 1.02f;
        }
    }
}




