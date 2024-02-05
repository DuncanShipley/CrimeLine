using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{


    /*
     * THIS IS NOTHING YET, DON'T WORRY ABOUT IT
     */

    public int health;

    void Start()
    {
        health = 5;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "proj")
        {
            health--;
        } // if it's hit by a projectile, decrease health
    }

    void Update()
    {
        if (health <= 0)
        {
            //Application.Quit();
        } // if it's health drops below 1, die
    }
}
