using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAttack : RangedAttack
{
    public override int damage
    {
        get { return 12; }

    }
    public override int speed
    {
        get { return 10; }

    }
    public override float time
    {
        get { return 5; }

    }
    public override bool limited 
    {
        get { return true; }

    }

    public override Vector3 knockback
    {
        get { return new Vector3(250 * dir, 100, 0); }

    }
    public override int height
    {
        get { return 7; }
    }
}
