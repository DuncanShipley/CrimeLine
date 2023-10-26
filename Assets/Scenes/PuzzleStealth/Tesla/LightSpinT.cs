using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpinT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (WaypointFollowerT.currentWaypointIndex == 1)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
        }
        if (WaypointFollowerT.currentWaypointIndex == 2)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90);
        }
        if (WaypointFollowerT.currentWaypointIndex == 3)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180);
        }
        if (WaypointFollowerT.currentWaypointIndex == 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 270);
        }
    }
}
