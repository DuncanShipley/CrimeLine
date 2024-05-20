using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class playerHealthMain : MonoBehaviour
{
    public Image endScreen;
    public GameObject endText;
    public GameObject test;

    public int health;
    bool dead = false;
    float stayTime = 0;


    void Start()
    {
        health = 5;
        endScreen = GameObject.Find("End Screen").GetComponent<Image>();
        endText = GameObject.Find("Game Over");
        endScreen.enabled = false;
        endText.SetActive(false);
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
        if (collision.name.Contains("laser")){
            stayTime = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D other){
        if (other.name.Contains("laser")){
            stayTime += Time.deltaTime;
            if (stayTime >= 1){
                stayTime = 0;
                health--;
                Debug.Log("laser stay, health = " + health);
            }
        }
    }

    IEnumerator Death()
    {
        dead = true;
        for (float i = 1; i >= 0; i -= .02f)
        {
            Time.timeScale = i;
            Time.fixedDeltaTime = .02f * Time.timeScale;
            yield return new WaitForSecondsRealtime(.05f);
        }
        Time.timeScale = 0; // gradually slow time to a stop
        endScreen.enabled = true;
        endText.SetActive(true); // make the endscreen appear
    }

    void Update()
    {
        if (health <= 0 && !dead)
        {
            StartCoroutine(Death());

        } // if it's health drops below 1 and it hasn't done it before, run the death function
    }
}