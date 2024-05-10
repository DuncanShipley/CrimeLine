using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardVariablesMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        guardChaseMain.sus.Add(0);
        guardChaseMain.chase.Add(false);
        guardChaseMain.alerting.Add(false);
        guardChaseMain.seeing.Add(false);
        guardChaseMain.oldPointIndex.Add(0);
        guardChaseMain.speed.Add(GetBaseSpeed());
        guardChaseMain.timesSeen.Add(0f);
        guardChaseMain.detectRadius.Add(75f);

        guardHealthMain.aliveList.Add(true);
        guardHealthMain.healthList.Add(2);
        guardHealthMain.dyingList.Add(false);
        guardHealthMain.dyingTimer.Add(0);

        AlertMain.alerted.Add(-1);

        WaypointFollowerMain.currentPointIndex.Add(0);
        WaypointFollowerMain.spottedPosition.Add(Vector3.zero);
        WaypointFollowerMain.movingLeft.Add(0);
        WaypointFollowerMain.lookingLeft.Add(false);
        WaypointFollowerMain.movingDown.Add(false);
        WaypointFollowerMain.lookingDown.Add(false);
        WaypointFollowerMain.movedDown.Add(false);
        WaypointFollowerMain.close.Add(false);

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
