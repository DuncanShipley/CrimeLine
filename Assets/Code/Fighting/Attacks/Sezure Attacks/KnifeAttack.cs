using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAttack : RangedAttack
{
    public override int damage
    {
        get { return 10; }

    }
    public override float speed
    {
        get { return 18f * -dir; }

    }

    public override Vector3 knockback
    {
        get { return new Vector3(100 * dir, 0, 0); }

    }

    public override int height
    {
        get { return 0; }
    }
    public override float time
    {
        get { return 5; }

    }
    public override bool limited
    {
        get { return true; }

    }
    public override bool Staged
    {
        get {return false;}
    }
}
