using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardHealthAlexis : MonoBehaviour
{
    public int id;
    public static List<int> healthList = new List<int>();
    public static List<bool> aliveList = new List<bool>();
    public static List<bool> dyingList = new List<bool>();
    public static List<double> dyingTimer = new List<double>();

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
        id = gameObject.transform.parent.GetComponent<IDsAlexis>().GetID();
        if (healthList[id] <= 0 && dyingTimer[id] < 2)
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


