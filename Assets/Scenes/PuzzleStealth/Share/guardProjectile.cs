using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardProjectile : MonoBehaviour
{
    public GameObject source;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Guard Projectile") { source = transform.parent.gameObject; }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Guard Projectile")
        {
            transform.position = source.transform.position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name != "Guard Projectile" && !collision.gameObject.Equals(source) && collision.name != "Sensor Range" && collision.name != "Guard Projectile")
        {
            Destroy(gameObject); // vanish when it hits something
        }

    }
}
