using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardChaseT : MonoBehaviour
{
    public GameObject Player;
    public static List<Vector3> startingPosition = new List<Vector3>();
    public static List<Vector3> position = new List<Vector3>();

    public int id;

    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        startingPosition.Add(Vector3.zero);
        position.Add(Vector3.zero);
    }
    // Update is called once per frame
    void Update()
    {
        if (time == 0f)
        {
            id = gameObject.transform.parent.GetComponent<IDsT>().GetID();  //first, set the guard's id.
        }
        if (time > 0.5f && time < 1f)
        {
            position[id] = transform.position;
            startingPosition[id] = position[id]; // saves the guard's starting position to return the waypoint to it later
        }
        if (time > 1f)
        {
            transform.position = position[id]; // after enough time has passed to set everything up, go!
        }
        time += Time.deltaTime;
    }
    public static void putWaypoint(Vector3 wpLocation, int GuardID)
    {
        position[GuardID] = wpLocation;
    }
}
