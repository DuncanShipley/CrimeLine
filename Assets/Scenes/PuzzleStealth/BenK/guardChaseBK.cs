using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardChaseBK : MonoBehaviour
{
    public GameObject Player;
    public static Vector3 position;
    public static Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position; // saves the guard's starting position to return the waypoint to it later
        startPosition = position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = position;
    }
    public static void putWaypoint(Vector3 wpLocation)
    {
        position = wpLocation;
    }
    public static void resetWaypoints()
    {
        position = startPosition;
    }
}


