using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasercodeTesla : MonoBehaviour
{
    public bool moving;
    public float[] waypoints;

    private int waypointIndex;
    private float curWaypoint;
    LineRenderer render;
    bool on = true;
    public GameObject lT;
    public GameObject gT;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<LineRenderer>();
        if (moving)
        {
            waypointIndex = 0; 
            curWaypoint = waypoints[0];
        }
        
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

    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("laser: " + gameObject.transform.position);
        lT.transform.position = gameObject.transform.position;
        gT.transform.position = collision.gameObject.transform.position;
        Debug.Log("guard: " + collision.gameObject.transform.position);
        if (collision.gameObject.name == "Sensor Range"){
            if (Vector2.Distance(collision.gameObject.transform.position, gameObject.transform.position) < 5f){
                render.enabled = false;
                on = false;
                //Debug.Log("off");
            }
            else{
                render.enabled = true;
                on = true;
                //Debug.Log("on: " + Vector2.Distance(collision.gameObject.transform.position, gameObject.transform.position));
            }
        }
    }
}
