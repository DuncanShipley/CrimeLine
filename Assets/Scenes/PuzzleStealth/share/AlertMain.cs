using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertMain : MonoBehaviour
{
    public int id;
    public static List<GameObject> guards = new List<GameObject>();
    public static List<int> alerted = new List<int>();
    public int alert;
    GameObject Waypoint1;

    // Start is called before the first frame update
    void Start()
    {
        Waypoint1 = GameObject.Find("Waypoint 1");
        guards.Add(gameObject);
        alerted.Add(-1);
    }

    // Update is called once per frame
    void Update()
    {
        id = gameObject.transform.parent.parent.GetComponent<IDsMain>().GetID();
        alert = alerted[id];
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "GuardSensor")
        {
            int otherID = collision.gameObject.transform.parent.parent.GetComponent<IDsMain>().GetID();


            if (guardChaseMain.alerting[otherID] && !guardChaseMain.seeing[id]) // if it gets close to a guard that's chasing and can't see the player
            {
                alerted[id] = otherID; // set alerted for the non-suspicious guard to the id of the sus one
                guardChaseMain.putWaypoint(collision.gameObject.transform.parent.position, id, Waypoint1);
            }
            else if (!guardChaseMain.alerting[otherID]) // if the other guard is no longer suspicious
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
