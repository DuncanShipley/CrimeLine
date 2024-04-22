using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertA : MonoBehaviour
{
    public int id;
    public static List<GameObject> guards = new List<GameObject>();
    public static List<int> alerted = new List<int>();
    public int alert;

    // Start is called before the first frame update
    void Start()
    {
        guards.Add(gameObject);
        alerted.Add(-1);
    }

    // Update is called once per frame
    void Update()
    {
        id = gameObject.transform.parent.parent.GetComponent<IDsA>().GetID();
        alert = alerted[id];
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "GuardSensor")
        {
            int otherID = collision.gameObject.transform.parent.parent.GetComponent<IDsA>().GetID();


            if (WaypointFollowerA.alerting[otherID] && !WaypointFollowerA.seeing[id]) // if it gets close to a guard that's chasing and can't see the player
            {
                alerted[id] = otherID; // set alerted for the non-suspicious guard to the id of the sus one
                guardChaseA.putWaypoint(collision.gameObject.transform.parent.position, id);
            }
            else if (!WaypointFollowerA.alerting[otherID]) // if the other guard is no longer suspicious
            {
                alerted[id] = -1; // end alerted
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GuardSensor")
        {
            alerted[id] = -1;
        }
    }
}
