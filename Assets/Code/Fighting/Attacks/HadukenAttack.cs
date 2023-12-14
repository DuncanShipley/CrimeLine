using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HadukenAttack : Attack
{
    private Rigidbody rb;
    public override int damage
    {
        get { return 5; }

    }

    public override Vector3 knockback
    {
        get { return new Vector3(-500, 200, 0); }

    }

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-10, 0,0);
    }
}
