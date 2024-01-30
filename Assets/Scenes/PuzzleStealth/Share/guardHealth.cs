using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardHealth : MonoBehaviour
{
    public int id;
    public static List<int> healthList = new List<int>();
    public static List<bool> aliveList = new List<bool>();
    // Start is called before the first frame update
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
        id = gameObject.transform.parent.GetComponent<IDs>().GetID();
        if (healthList[id] <= 0)
        {
            aliveList[id] = false;
        } // if it's health drops below 1, die
    }
}
