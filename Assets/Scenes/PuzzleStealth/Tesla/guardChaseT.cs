using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardChaseT : MonoBehaviour
{
    public GameObject Player;
    Vector3 startingPosition;


    public int id;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        startingPosition = transform.position; // saves the guard's starting position to return the waypoint to it later


    }

    // Update is called once per frame
    void Update()
    {
        id = gameObject.transform.parent.GetComponent<IDsT>().GetID();

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
