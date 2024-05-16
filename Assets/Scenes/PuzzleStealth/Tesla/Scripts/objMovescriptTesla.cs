using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class objMovescriptTesla : MonoBehaviour
{
    public int[] waypoints;
    public float spd;

    private Rigidbody2D rb;
    private int currentWaypoint = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inp;

        if(waypoints[currentWaypoint] > transform.position.x)
        {
            inp = new Vector3(spd / 20f, 0, 0);
        }
        else
        {
            inp = new Vector3(-spd / 20f, 0, 0);
        }

        rb.MovePosition(transform.position + inp);

        Debug.Log(inp);

        if(Math.Abs(waypoints[currentWaypoint] - transform.position.x) < 1)
        {
            if(currentWaypoint >= waypoints.Length - 1)
            {
                currentWaypoint = 0;
            }
            else
            {
                currentWaypoint++;
            }
        }
    }
}
