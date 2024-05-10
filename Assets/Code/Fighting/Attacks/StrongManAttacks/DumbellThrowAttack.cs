using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbellThrowAttack : RangedAttack
{
    public override int damage
    {
        get {return 3;}
    }
    public override Vector3 knockback 
    {
        get{return new Vector3(200,-100,0);}
    }
    public override int speed
    {
        get {return 10;}
    }
    public override int height
    {
        get {return 3;}
    }
    public override float time
    {
        get { return 5; }

    }
    public override bool limited 
    {
        get { return true; }

    }
}
