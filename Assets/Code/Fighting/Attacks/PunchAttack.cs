using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PunchAttack : Attack
{
    public override int damage
    {
        get { return 10; }

    }

    public override Vector3 knockback
    {
        get { return new Vector3(-200,800,0); }

    }
}
