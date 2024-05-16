using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardProjectileTesla : MonoBehaviour
{
    public GameObject source;
    float timeExisting = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Guard Projectile") { source = transform.parent.gameObject; }
    }

    // Update is called once per frame
    void Update()
    {
        timeExisting += Time.deltaTime;
        if (gameObject.name == "Guard Projectile")
        {
            transform.position = source.transform.position;
        }
        if (timeExisting > 60 && gameObject.name != "Guard Projectile"){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name != "Guard Projectile" && !collision.gameObject.Equals(source) && collision.name != "Sensor Range" && collision.name != "Guard Projectile")
        {
            Destroy(gameObject); // vanish when it hits something
        }

    }
}
