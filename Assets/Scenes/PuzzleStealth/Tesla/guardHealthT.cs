using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardHealthT : MonoBehaviour
{
    public static bool alive = true;
    public int health;

    public static List<int> healthList = new List<int>();
    public static List<bool> aliveList = new List<bool>();
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "proj")
        {
            health--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            alive = false;
        }
    }
}
