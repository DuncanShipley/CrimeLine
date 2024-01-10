using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasercode : MonoBehaviour
{
    public bool moving;
    public float[] waypoints;

    private int waypointIndex;
    private float curWaypoint;
    

    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0; 
        curWaypoint = waypoints[waypointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            

            if (curWaypoint > gameObject.transform.position.y) 
            {
                gameObject.transform.position += new Vector3(0f, 0.1f, 0.0f);
            }
            else if (curWaypoint < gameObject.transform.position.y) 
            {
                gameObject.transform.position -= new Vector3(0f, 0.1f, 0.0f);
            }

            if (Mathf.Abs(gameObject.transform.position.y - curWaypoint) < 0.1)
            {
                waypointIndex++;
                if (waypointIndex >= 2)
                {
                    waypointIndex = 0;
                }

                curWaypoint = waypoints[waypointIndex];
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
