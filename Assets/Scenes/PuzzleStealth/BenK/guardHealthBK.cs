using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardHealthBK : MonoBehaviour
{
    public static bool alive = true;
    public int health;
    public float deathTimer = 2f;
    public static bool dying = false;
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
        if (health <= 0 && deathTimer > 0)
        {
            dying = true;
            deathTimer = deathTimer - Time.deltaTime;
        }
        if (health <= 0 && deathTimer <= 0)
        {
            dying = false;
            alive = false;
        }
    }
}
