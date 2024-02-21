using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardShootT : MonoBehaviour
{
    GameObject copy;
    float throwPause = 0;
    public int id;
    public GameObject projectile;
    public float waitTime;

    // Start is called before the first frame update

    void Start()
    {
        waitTime = transform.parent.GetComponent<GuardVariablesT>().GetShootWait();
    }

    void Update()
    {
        id = gameObject.transform.parent.GetComponent<IDsT>().GetID();


        throwPause += Time.deltaTime;

        if (WaypointFollowerT.chase[id] && throwPause > waitTime)
        {
            copy = Instantiate(projectile, transform.position, gameObject.transform.rotation); // create a projectile at the guard's location
            throwPause = 0;
            var pRB = copy.GetComponent<Rigidbody2D>();
            pRB.AddRelativeForce(Vector3.up*2000); // move in the same direction as last player movement
            copy.name = "Guard Shot";
            copy.tag = "DamagePlayer";
        }
    }


    
}
