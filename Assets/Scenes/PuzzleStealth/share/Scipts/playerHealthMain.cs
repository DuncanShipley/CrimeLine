using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playerHealthMain : MonoBehaviour
{
    private Image endScreen;
    private GameObject endText;
    private GameObject test;

    public int health;
    bool dead = false;
    

    void Start()
    {
    }
    public void Awake()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DamagePlayer")
        {
            health--;
        } // if it's hit by something damaging, decrease health
    }
    void Update()
    {
    }
}
