using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarCyclonePart2 : Attack
{
    public override int damage
    {
        get {return 2;}
    }
    public override Vector3 knockback 
    {
        get{return new Vector3(0,50,0);}
    }
    public override bool Staged
    {
        get {return true;}
    }
}
