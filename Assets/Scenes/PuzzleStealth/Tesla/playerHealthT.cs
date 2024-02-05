using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playerHealthT : MonoBehaviour
{
    /*
     * THIS IS NOTHING YET, DON'T WORRY ABOUT IT
     */

    public Image endScreen;

    public int health;
    bool dead = false;

    void Start()
    {
        health = 5;
        endScreen = GameObject.Find("End Screen").GetComponent<Image>();
        endScreen.enabled = false;
        Debug.Log("hide");
    }
    public void Awake()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "DamagePlayer")
        {
            health--;
        }
    }

    //IEnumerator Death()
    //{
    //    dead = true;
    //    for (float i = 1; i >= 0.1; i -= .01f)
    //    {
    //        Time.timeScale = i;
    //        Time.fixedDeltaTime = .02f * Time.timeScale;
    //        yield return new WaitForSecondsRealtime(.05f);
    //        Debug.Log(i);
    //    }
    //    Time.timeScale = 0;
    //    endScreen.enabled = true;
    //    Debug.Log("dead");
    //}

    void Update()
    {
        if (health <= 0 && !dead)
        {
            //StartCoroutine(Death());
            dead = true;
            Time.timeScale = 0;
            endScreen.enabled = true;
            Debug.Log("dead");

        } // if it's health drops below 1, stop moving and make endscreen appear
    }
}
