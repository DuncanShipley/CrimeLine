using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaypointFollowerTesla : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    public GameObject Waypoint1;
    public static GameObject[] wpref;
    private float guardWait = 0f;
    int movingLeft;
    bool movingDown;
    public double relAngle;
    private float atan;
    public bool canMove = true;

    public int id;

    public static List<int> currentPointIndex = new List<int>();
    public static List<int> tempList = new List<int>();
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
        movingLeft = 0;
        movingDown = false;

        currentPointIndex.Add(0);
        startingPosition = transform.position;

        guard = GetComponent<UnityEngine.AI.NavMeshAgent>();
        guard.updateRotation = false;
        guard.updateUpAxis = false;
    }

    private void Update()
    {
        if (gameObject.tag == "NPC"){
            
        }
        id = gameObject.transform.parent.GetComponent<IDsTesla>().GetID();

        if (canMove)
        {
            // Debug.Log(Vector2.Distance(waypoints[currentPointIndex[id]].transform.position, transform.position));
            if (Vector2.Distance(waypoints[currentPointIndex[id]].transform.position, transform.position) < 1.2f && guardWait <= 1 && !guardChaseTesla.endedChase[id]) // if you're close and you haven't waited
            {
                guardWait += Time.deltaTime; // wait
            }
            else if(guardChaseTesla.endedChase[id] && Vector2.Distance(waypoints[currentPointIndex[id]].transform.position, transform.position) < 1.2f){
                transform.Rotate(new Vector3(0, 360, 0) * Time.deltaTime);
                guardWait += Time.deltaTime;
                //Debug.Log("spinning");
                if (guardWait >= 1){
                    //Debug.Log("ended spin");
                    guardChaseTesla.endedChase[id] = false;
                }
            }
            else if (guardWait >= 1) // once you've waited (and are still close)
            {
                if (gameObject.tag == "NPC"){ currentPointIndex[id] = UnityEngine.Random.Range(0, waypoints.Length); Debug.Log(currentPointIndex[id]); }
                else { currentPointIndex[id]++; } // look towards the next waypoint
                guardChaseTesla.putWaypoint(startingPosition, id, Waypoint1);
                if (currentPointIndex[id] >= waypoints.Length)
                {
                    currentPointIndex[id] = 0;
                }
                guardWait = 0; // reset wait timer
                //transform.position = Vector2.MoveTowards(transform.position, waypoints[currentPointIndex[id]].transform.position, Time.deltaTime * speed[id]);
                //guard.SetDestination(waypoints[currentPointIndex[id]].transform.position);
            }
            else if (guardChaseTesla.sus[id] == 0 || guardChaseTesla.sus[id] == 1)
            {
                guard.SetDestination(waypoints[currentPointIndex[id]].transform.position); // move towards waypoint
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
            if (waypoints[currentPointIndex[id]].transform.position.y > transform.position.y && waypoints[currentPointIndex[id]].transform.position.x > transform.position.x) // if the current waypoint is up and to the right of us
            {
                relAngle = Math.Atan((waypoints[currentPointIndex[id]].transform.position.y - transform.position.y) / (waypoints[currentPointIndex[id]].transform.position.x - transform.position.x)) * 180 / Math.PI;
            }
            else if (waypoints[currentPointIndex[id]].transform.position.x < transform.position.x) // if it's to the left of us
            {
                relAngle = Math.Atan((waypoints[currentPointIndex[id]].transform.position.y - transform.position.y) / (waypoints[currentPointIndex[id]].transform.position.x - transform.position.x)) * 180 / Math.PI + 180;
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
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, (float)(atan * 180 / Math.PI) - 90 + movingLeft); // point towards current waypoint
        }
        else
        {
            rb.velocity /= 1.02f;
            rb.angularVelocity /= 1.02f;
        }
    }
}




