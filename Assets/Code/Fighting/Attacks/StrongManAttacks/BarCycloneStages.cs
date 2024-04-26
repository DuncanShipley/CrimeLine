using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarCycloneStages : StagedAttack
{
    public GameObject Stage1;
    public GameObject Stage2;
    public GameObject Stage3;
    public GameObject Stage4;
    public override GameObject[] Stages
    {
        get {return new GameObject[]{Stage1, Stage2, Stage3, Stage4};}
    }
}
