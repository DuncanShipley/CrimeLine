using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardChase : MonoBehaviour
{
    public GameObject Player;
    public Vector3 startingPosition;

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
        id = gameObject.transform.parent.GetComponent<IDs>().GetID();

        if (WaypointFollower.chase[id]) // while the guard is chasing the player,
        {
            transform.position = Player.transform.position; // put this waypoint on the player.
        }
        if (Alert.alerted[id] > -1) // while the guard is alerted
        {
            transform.position = Alert.guards[Alert.alerted[id]].transform.position; // put this waypoint on the alerting guard.
        }
        if (!WaypointFollower.chase[id] && Alert.alerted[id] == -1) // whey they stop,
        {
            transform.position = startingPosition; // return this waypoint to its starting position.
        }
    }
}
