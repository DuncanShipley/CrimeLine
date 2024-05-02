using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarCycloneStages : StagedAttack
{
    public GameObject Stage1;
    public GameObject Stage2;
    public GameObject Stage3;
    public GameObject Stage4;
    public override int Stages
    {
        get {return 4;}
    }
}
