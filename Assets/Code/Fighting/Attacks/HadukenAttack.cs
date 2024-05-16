using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HadukenAttack : RangedAttack
{
    public override int damage
    {
        get { return 5; }

    }
    public override int speed
    {
        get { return 10; }

    }

    public override Vector3 knockback
    {
        get { return new Vector3(500 * dir, 200, 0); }

    }
    

    public override int height
    {
        get { return 0; }
    }
    public override float time
    {
        get { return 0; }

    }
    public override bool limited
    {
        get { return false; }

    }



}
