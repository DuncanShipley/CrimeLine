using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarCyclonePart4 : Attack
{
    public override int damage
    {
        get {return 3;}
    }
    public override Vector3 knockback 
    {
        get{return new Vector3(200,500,0);}
    }

    public override bool Staged
    {
        get {return true;}
    }
}
