using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardVariablesTesla : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        guardChaseTesla.currentPointIndex.Add(0);
        guardChaseTesla.sus.Add(0);
        guardChaseTesla.chase.Add(false);
        guardChaseTesla.alerting.Add(false);
        guardChaseTesla.seeing.Add(false);
        guardChaseTesla.oldPointIndex.Add(0);
        guardChaseTesla.endedChase.Add(false);
        guardChaseTesla.speed.Add(GetBaseSpeed());
        guardChaseTesla.timesSeen.Add(0f);

        guardHealthTesla.aliveList.Add(true);
        guardHealthTesla.healthList.Add(2);
        guardHealthTesla.dyingList.Add(false);
        guardHealthTesla.dyingTimer.Add(0);
        guardHealthTesla.stunList.Add(1);

        AlertTesla.alerted.Add(-1);

        WaypointFollowerTesla.currentPointIndex.Add(0);
        WaypointFollowerTesla.spottedPosition.Add(Vector3.zero);
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
