using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardHealthT : MonoBehaviour
{
    public int id;
    public static List<int> healthList = new List<int>();
    public static List<bool> aliveList = new List<bool>();

    void Start()
    {
        aliveList.Add(true);
        healthList.Add(2);
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
        id = gameObject.transform.parent.GetComponent<IDsT>().GetID();
        if (healthList[id] <= 0)
        {
            aliveList[id] = false;
        } // if it's health drops below 1, die
    }
}
