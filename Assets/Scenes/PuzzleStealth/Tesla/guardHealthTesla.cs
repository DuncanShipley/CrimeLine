using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardHealthTesla : MonoBehaviour
{
    public int id;
    public static List<int> healthList = new List<int>();
    public static List<bool> aliveList = new List<bool>();
    public static List<bool> dyingList = new List<bool>();
    public static List<double> dyingTimer = new List<double>();
    public static List<int> stunList = new List<int>();

    void Start()
    {
        // aliveList.Add(true);
        // healthList.Add(2);
        // dyingList.Add(false);
        // dyingTimer.Add(0);
        // stunList.Add(1);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "proj" && stunList[id] > 0)
        {
            stunList[id]--;
            Debug.Log(stunList[id]);
        } // if it's hit by a projectile, decrease health
    }

    void Update()
    {
        id = gameObject.transform.parent.GetComponent<IDsTesla>().GetID();
        if (stunList[id] <= 0) // if its been hit, freeze for three seconds
        {
            stunList[id] = 1;
        }
        else if (healthList[id] <= 0 && dyingTimer[id] < 2)
        {
            aliveList[id] = false;
            dyingList[id] = true;
            dyingTimer[id] = dyingTimer[id] + Time.deltaTime;
        } // if it's health drops below 1, die
        else if (dyingTimer[id] < 2)
        {
            aliveList[id] = true;
            dyingList[id] = false;
        }
        else
        {
            aliveList[id] = false;
            dyingList[id] = false;
        }
    }
}
