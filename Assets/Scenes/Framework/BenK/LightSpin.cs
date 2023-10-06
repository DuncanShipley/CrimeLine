using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (WaypointFollower.currentWaypointIndex == 1)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
        }
        if (WaypointFollower.currentWaypointIndex == 2)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90);
        }
        if (WaypointFollower.currentWaypointIndex == 3)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180);
        }
        if (WaypointFollower.currentWaypointIndex == 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 270);
        }
        Debug.Log(WaypointFollower.currentWaypointIndex);
    }
}
