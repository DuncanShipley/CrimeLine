using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpikeAttack : Attack
{
    public override Vector3 knockback
    {
        get { return new Vector3(100*dir, 700, 0); }

    }
    public override int damage
    {
        get { return 10; }

    }
    public override bool Staged
    {
        get {return false;}
    }
}
