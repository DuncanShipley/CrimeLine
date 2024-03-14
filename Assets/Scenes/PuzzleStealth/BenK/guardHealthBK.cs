using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardHealthBK : MonoBehaviour
{
    public int id;
    public static List<int> healthList = new List<int>();
    public static List<bool> aliveList = new List<bool>();
    public static List<bool> dyingList = new List<bool>();
    public static List<double> dyingTimer = new List<double>();
    public float zrotation = 0;

    void Start()
    {
        aliveList.Add(true);
        healthList.Add(2);
        dyingList.Add(false);
        dyingTimer.Add(0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "proj")
        {
            healthList[id]--;
        } // if it's hit by a projectile, decrease health
    }

    void Update()
    {
        id = gameObject.transform.parent.GetComponent<IDs>().GetID();
        if (healthList[id] <= 0 && dyingTimer[id] < 2)
        {
            aliveList[id] = false;
            dyingList[id] = true;
            dyingTimer[id] = dyingTimer[id] + Time.deltaTime;
            GetComponent<WaypointFollowerBK>().canMove = false;
            zrotation += 360 * Time.deltaTime;
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, zrotation);
        } // if it's health drops below 1, die
        else if (dyingTimer[id] < 2)
        {
            aliveList[id] = true;
            dyingList[id] = false;
            GetComponent<WaypointFollowerBK>().canMove = true;
            zrotation = transform.eulerAngles.z;
        }
        else
        {
            aliveList[id] = false;
            dyingList[id] = false;
            GetComponent<WaypointFollowerBK>().canMove = false;
        }
    }
}


