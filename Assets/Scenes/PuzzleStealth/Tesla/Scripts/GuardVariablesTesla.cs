using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardVariablesTesla : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        guardChaseTesla.sus.Add(0);
        guardChaseTesla.chase.Add(false);
        guardChaseTesla.alerting.Add(false);
        guardChaseTesla.seeing.Add(false);
        guardChaseTesla.oldPointIndex.Add(0);
        guardChaseTesla.speed.Add(GetBaseSpeed());
        guardChaseTesla.timesSeen.Add(0f);
        guardChaseTesla.detectRadius.Add(75f);

        guardHealthTesla.aliveList.Add(true);
        guardHealthTesla.healthList.Add(2);
        guardHealthTesla.dyingList.Add(false);
        guardHealthTesla.dyingTimer.Add(0);

        AlertTesla.alerted.Add(-1);

        WaypointFollowerTesla.currentPointIndex.Add(0);
        WaypointFollowerTesla.spottedPosition.Add(Vector3.zero);
        WaypointFollowerTesla.movingLeft.Add(0);
        WaypointFollowerTesla.lookingLeft.Add(false);
        WaypointFollowerTesla.movingDown.Add(false);
        WaypointFollowerTesla.lookingDown.Add(false);
        WaypointFollowerTesla.movedDown.Add(false);
        WaypointFollowerTesla.close.Add(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float GetChaseSpeed()
    {
        if (name == "Elite Guard") { return 5f; }
        else { return 4.5f; }
    }
    public float GetBaseSpeed()
    {
        return 3f;
    }
    public int GetHealth()
    {
        if (name == "Elite Guard") { return 4; }
        else { return 2; }
    }
    public float GetShootWait()
    {
        if (name == "Elite Guard") { return 0.25f; }
        else { return 0.5f; }
    }
}
