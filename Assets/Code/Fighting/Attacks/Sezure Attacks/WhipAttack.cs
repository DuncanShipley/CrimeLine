using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipAttack : Attack
{
    public override int damage
    {
        get { return 5; }

    }

    public override Vector3 knockback
    {
        get { return new Vector3(700*(-dir), 100, 0); }

    }
    public override bool Staged
    {
        get {return false;}
    }
}
