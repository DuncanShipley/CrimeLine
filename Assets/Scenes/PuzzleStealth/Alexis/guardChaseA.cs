using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardChaseA : MonoBehaviour
{
    public GameObject Player;
    public Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position; // saves the guard's starting position to return the waypoint to it later
    }

    // Update is called once per frame
    void Update()
    {
        if (WaypointFollower.chase) // while the guard is chasing the player,
        {
            transform.position = Player.transform.position; // put this waypoint on the player.
        }
        else // whey they stop,
        {
            transform.position = startingPosition; // return this waypoint to its starting position.
        }
    }
}
