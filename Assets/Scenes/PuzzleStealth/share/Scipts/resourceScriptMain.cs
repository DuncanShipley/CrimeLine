using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resourceScriptMain : MonoBehaviour
{
    private playerHealthMain health;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 30);
        health = GameObject.Find("Player").GetComponent<playerHealthMain>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(health.health * 100, 30);
    }
}
