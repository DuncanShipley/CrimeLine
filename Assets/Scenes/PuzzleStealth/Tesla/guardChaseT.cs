using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardChaseT : MonoBehaviour
{
    public GameObject Player;
    public Vector3 startingPosition;


    public static int ids = 0;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position; // saves the guard's starting position to return the waypoint to it later


        id = ids;
        ids++;
    }

    // Update is called once per frame
    void Update()
    {
        if (WaypointFollowerT.chaseList[id]) // while the guard is chasing the player,
        {
            transform.position = Player.transform.position; // put this waypoint on the player.
        }
        else // whey they stop,
        {
            transform.position = startingPosition; // return this waypoint to its starting position.
        }
    }
}
