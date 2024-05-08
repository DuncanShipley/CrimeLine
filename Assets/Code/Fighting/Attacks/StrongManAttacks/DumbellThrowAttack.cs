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
        get{return new Vector3(200,-100,0)}
    }
}
