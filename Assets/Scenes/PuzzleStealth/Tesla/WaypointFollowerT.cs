using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollowerT : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    static public int currentWaypointIndex = 0;
    private float guardWait = 0f;

    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f && guardWait <= 1) // if you're close and you haven't waited
        {
            guardWait = guardWait + Time.deltaTime; // wait
            
        }
        else if (guardWait >= 1) // once you've waited (and are still close)
        {
            currentWaypointIndex++; // look towards the next waypoint
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
            guardWait = 0; // reset wait timer
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        }
    }
}
