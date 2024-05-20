using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarCyclonePart1A3 : Attack
{
    public override int damage
    {
        get {return 2;}
    }

    public override Vector3 knockback 
    {
        get{return new Vector3(0,200,0);}
    }
    public override bool Staged
    {
        get {return true;}
    }
}
