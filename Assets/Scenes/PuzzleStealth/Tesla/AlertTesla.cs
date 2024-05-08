using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertTesla : MonoBehaviour
{
    public int id;
    public static List<int> alerted = new List<int>();
    public int alert;
    Transform Waypoint1;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        Waypoint1 = this.gameObject.transform.parent.parent.GetChild(1);
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        id = gameObject.transform.parent.parent.GetComponent<IDsTesla>().GetID();
        alert = alerted[id];
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "GuardSensor")
        {
            int otherID = collision.gameObject.transform.parent.parent.GetComponent<IDsTesla>().GetID();


            if (guardChaseTesla.alerting[otherID] && !guardChaseTesla.seeing[id] && Vector2.Distance(collision.gameObject.transform.position, this.gameObject.transform.position) > 5f) // if it gets close to a guard that's chasing and can't see the player
            {
                alerted[id] = otherID; // set alerted for the non-suspicious guard to the id of the sus one
                if (gameObject.tag != "NPC") {guardChaseTesla.putWaypoint(collision.gameObject.transform.parent.position, id, Waypoint1);}
                Debug.Log("moved to guard by alert, far");
            }
            else if (guardChaseTesla.alerting[otherID] && !guardChaseTesla.seeing[id]){
                guardChaseTesla.putWaypoint(player.position, id, Waypoint1);
                Debug.Log("moved to player by alert, close");
            }
            else if (!guardChaseTesla.alerting[otherID]) // if the other guard is no longer suspicious
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
