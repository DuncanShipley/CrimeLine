using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UppercutAttack : Attack
{
    public override int damage
    {
        get { return 15; }

    }

    public override Vector3 knockback
    {
        get { return new Vector3(200*dir, 800, 0); }

    }
}
