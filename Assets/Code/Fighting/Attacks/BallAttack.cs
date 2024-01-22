using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAttack : RangedAttack
{
    public override int damage
    {
        get { return 5; }

    }
    public override int speed
    {
        get { return 10; }

    }
    public override float time
    {
        get { return 0; }

    }
    public override bool limited 
    {
        get { return false; }

    }

    public override Vector3 knockback
    {
        get { return new Vector3(500 * dir, 200, 0); }

    }
    public override int height
    {
        get { return 10; }
    }
}
