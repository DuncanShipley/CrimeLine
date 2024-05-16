using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasercodeTesla : MonoBehaviour
{
    public bool moving;
    public float[] waypoints;

    private int waypointIndex;
    private float curWaypoint;
    Renderer render;
    bool on = true;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        waypointIndex = 0; 
        curWaypoint = waypoints[0];
        
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
        if (collision.gameObject.name == "Sensor Range"){
            if (Vector2.Distance(collision.gameObject.transform.position, gameObject.transform.position) < 3f){
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
