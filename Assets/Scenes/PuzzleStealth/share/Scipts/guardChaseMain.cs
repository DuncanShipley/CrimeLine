using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardChaseMain : MonoBehaviour
{
    public GameObject Player;
    public Transform Waypoint1;
    public static List<Vector3> startingPosition = new List<Vector3>();
    public static List<Vector3> positionList = new List<Vector3>();

    public float leftDetectEdge;
    public float rightDetectEdge;
    public static List<float> detectRadius = new List<float>(); 
    private bool seesPlayer;
    public static List<float> sus = new List<float>();
    public static List<bool> chase = new List<bool>();
    public static List<bool> seeing = new List<bool>();
    public static List<int> oldPointIndex = new List<int>();
    public static List<bool> alerting = new List<bool>();
    
    [SerializeField] public static List<float> speed = new List<float>();
    public static List<float> timesSeen = new List<float>();

    float baseSpeed;
    float chaseSpeed;

    bool movingLeft;
    bool movingUp;
    RaycastHit2D seeingRay;

    public int id;

    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Waypoint1 = this.gameObject.transform.parent.GetChild(1);
        startingPosition.Add(Vector3.zero);
        positionList.Add(Vector3.zero);

        baseSpeed = gameObject.transform.parent.GetComponent<GuardVariablesMain>().GetBaseSpeed();
        chaseSpeed = gameObject.transform.parent.GetComponent<GuardVariablesMain>().GetChaseSpeed();
    }
    // Update is called once per frame
    void Update()
    {
        seesPlayer = CheckFor(Player);
        GetComponent<UnityEngine.AI.NavMeshAgent>().speed = speed[id];

        if (WaypointFollowerMain.close[id]){
            movingLeft = WaypointFollowerMain.lookingLeft[id];
            if (WaypointFollowerMain.movedDown[id]){
                movingUp = !WaypointFollowerMain.lookingDown[id];
            }
            else{
                movingUp = WaypointFollowerMain.lookingDown[id];
            }
        }
        else{
            movingLeft = (WaypointFollowerMain.movingLeft[id] == 180);
            movingUp = !WaypointFollowerMain.movingDown[id];
        }

        leftDetectEdge = transform.eulerAngles.z - 270 - detectRadius[id] / 2;
        rightDetectEdge = transform.eulerAngles.z - 90 + detectRadius[id] / 2;
        if (leftDetectEdge < -detectRadius[id] / 2)
        {
            leftDetectEdge += 360;
        }
        if (rightDetectEdge < detectRadius[id] / 2)
        {
            rightDetectEdge += 360;
        } // establish the radii within which the guard can detect the player
        if (Vector2.Distance(transform.position, Player.transform.position) < detectRadius[id] / 7 && seesPlayer) // if the player is within the guard's light
        {
            if (sus[id] < 1) // and the guard isn't suspicious
            {
                sus[id] = sus[id] + 10 * Time.deltaTime / Vector2.Distance(transform.position, Player.transform.position) + timesSeen[id] / 10; // increase the guard's suspicion
            }
            else // if they are suspicious, begin chasing the player
            {
                chase[id] = true;
                AlertMain.alerted[id] = -1;
                seeing[id] = true;
                oldPointIndex[id] = WaypointFollowerMain.currentPointIndex[id];
                WaypointFollowerMain.currentPointIndex[id] = 0;
                detectRadius[id] = 121;
                speed[id] = chaseSpeed;
                sus[id] = 1;
                alerting[id] = true;
                WaypointFollowerMain.spottedPosition[id] = this.gameObject.transform.position;
                
            }
        }
        else if (AlertMain.alerted[id] > -1)
        {
            detectRadius[id] = 121;
            speed[id] = 6f;
            oldPointIndex[id] = WaypointFollowerMain.currentPointIndex[id];
            WaypointFollowerMain.currentPointIndex[id] = 0;
            speed[id] = chaseSpeed;
        }
        else if (sus[id] > 0) // if they're suspicious and the player isn't within their light, decrease their suspicion
        {
            sus[id] = sus[id] - 0.5f * Time.deltaTime;
            AlertMain.alerted[id] = -1;
            alerting[id] = false;
            seeing[id] = false;
        }
        else // if none of those are true, end the chase
        {
            if (speed[id] == chaseSpeed) { timesSeen[id]++; }
            chase[id] = false;
            detectRadius[id] = 81;
            speed[id] = baseSpeed;
            sus[id] = 0;
            alerting[id] = false;
            seeing[id] = false;
        }
        if (time == 0f)
        {
            id = gameObject.transform.parent.GetComponent<IDsMain>().GetID();  //first, set the guard's id.
        }
        if (time > 0.5f && time < 1f)
        {
            positionList[id] = transform.position;
            startingPosition[id] = positionList[id]; // saves the guard's starting position to return the waypoint to it later
        }
        time += Time.deltaTime;
    }
    public static void putWaypoint(Vector3 wpLocation, int GuardID, Transform wp, bool prior)
    {
        wp.position = wpLocation;
        if (prior){
            oldPointIndex[GuardID] = WaypointFollowerMain.currentPointIndex[GuardID];
            WaypointFollowerMain.currentPointIndex[GuardID] = 0;
        }
    }
    public bool CheckFor(GameObject cf)
    {
        if (WaypointFollowerMain.close[id]) {
            seeingRay = Physics2D.Raycast(transform.position, new Vector2((float)-Math.Sin(transform.rotation.eulerAngles.z * Math.PI / 180), (float)Math.Cos(transform.rotation.eulerAngles.z * Math.PI / 180)), (float)Math.Sqrt(detectRadius[id]), Physics.DefaultRaycastLayers, -Mathf.Infinity, Mathf.Infinity);
            //Debug.DrawRay(transform.position, new Vector2((float)-Math.Sin(transform.rotation.eulerAngles.z * Math.PI / 180), (float)Math.Cos(transform.rotation.eulerAngles.z * Math.PI / 180)));
            if (seeingRay.collider != null)
            {
                if (seeingRay.collider.gameObject == cf)
                {
                    putWaypoint(seeingRay.collider.gameObject.transform.position, id, Waypoint1, true);
                    return true;
                }
            }
        }
        else {
            for (float i = 0; i < 50; i++)
            {
                if (movingUp && !movingLeft){
                    seeingRay = Physics2D.Raycast(transform.position, new Vector2((float)-Math.Sin((((50 - i) * (leftDetectEdge+360) * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos((((50 - i) * (leftDetectEdge+360) * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50)), (float)Math.Sqrt(detectRadius[id]), Physics.DefaultRaycastLayers, -Mathf.Infinity, Mathf.Infinity);
                    //Debug.DrawRay(transform.position, new Vector2((float)-Math.Sin((((50 - i) * (leftDetectEdge+360) * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos((((50 - i) * (leftDetectEdge+360) * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50)));
                }
                else{
                    seeingRay = Physics2D.Raycast(transform.position, new Vector2((float)-Math.Sin((((50 - i) * (leftDetectEdge) * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos((((50 - i) * (leftDetectEdge) * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50)), (float)Math.Sqrt(detectRadius[id]), Physics.DefaultRaycastLayers, -Mathf.Infinity, Mathf.Infinity);
                    //Debug.DrawRay(transform.position, new Vector2((float)-Math.Sin((((50 - i) * (leftDetectEdge) * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos((((50 - i) * (leftDetectEdge) * Math.PI / 180) + i * transform.rotation.eulerAngles.z * Math.PI / 180) / 50)));
                }
                if (seeingRay.collider != null)
                {
                    if (seeingRay.collider.gameObject == cf)
                    {
                        putWaypoint(seeingRay.collider.gameObject.transform.position, id, Waypoint1, true);
                        return true;
                    }
                }
                if (movingUp && movingLeft){
                    seeingRay = Physics2D.Raycast(transform.position, new Vector2((float)-Math.Sin(((i * (rightDetectEdge-360) * Math.PI / 180) + (50 - i) * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos(((i * (rightDetectEdge-360) * Math.PI / 180) + (50 - i) * transform.rotation.eulerAngles.z * Math.PI / 180) / 50)), (float)Math.Sqrt(detectRadius[id]), Physics.DefaultRaycastLayers, -Mathf.Infinity, Mathf.Infinity);
                    //Debug.DrawRay(transform.position, new Vector2((float)-Math.Sin(((i * (rightDetectEdge-360) * Math.PI / 180) + (50 - i) * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos(((i * (rightDetectEdge-360) * Math.PI / 180) + (50 - i) * transform.rotation.eulerAngles.z * Math.PI / 180) / 50)));
                }
                else{
                    seeingRay = Physics2D.Raycast(transform.position, new Vector2((float)-Math.Sin(((i * (rightDetectEdge) * Math.PI / 180) + (50 - i) * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos(((i * (rightDetectEdge) * Math.PI / 180) + (50 - i) * transform.rotation.eulerAngles.z * Math.PI / 180) / 50)), (float)Math.Sqrt(detectRadius[id]), Physics.DefaultRaycastLayers, -Mathf.Infinity, Mathf.Infinity);
                    //Debug.DrawRay(transform.position, new Vector2((float)-Math.Sin(((i * (rightDetectEdge) * Math.PI / 180) + (50 - i) * transform.rotation.eulerAngles.z * Math.PI / 180) / 50), (float)Math.Cos(((i * (rightDetectEdge) * Math.PI / 180) + (50 - i) * transform.rotation.eulerAngles.z * Math.PI / 180) / 50)));
                }
                if (seeingRay.collider != null)
                {
                    if (seeingRay.collider.gameObject == cf)
                    {
                        putWaypoint(seeingRay.collider.gameObject.transform.position, id, Waypoint1, true);
                        return true;
                    }
                }
            }
        }
        
        return false;
    }
}

