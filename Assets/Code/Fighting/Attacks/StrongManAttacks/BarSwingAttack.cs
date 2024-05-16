using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarSwingAttack : Attack
{
    public override int damage
    {
        get {return 2;}
    }

    public override Vector3 knockback
    {
        get {return new Vector3(350,200,0);}
    }
}

