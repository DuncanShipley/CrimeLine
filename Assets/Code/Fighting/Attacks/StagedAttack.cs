using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StagedAttack : MonoBehaviour
{
    //todo get something      dun dun dun dun dun dun dun dun dun dun dun dn dun dun dun dun dun dun dun dun nah nvmd

    public virtual int Stages {get; set;}

    public void Awake()
    {
        Reset();
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Invoke("NextStage", 1);
    }

    public void NextStage()
    {
        int stage = FindStage(Stages);
        if (stage == Stages-1)
        {
            Reset();
            return;
        }
        this.gameObject.transform.GetChild(stage).gameObject.SetActive(false);
        this.gameObject.transform.GetChild(stage+1).gameObject.SetActive(true);
        Invoke("NextStage", 1);
    }

    public int FindStage(int stages)
    {

        for(int i = 0; i<stages; i++)
        {
            if (this.gameObject.transform.GetChild(i).gameObject.activeSelf)
            {
                return i;
            }

        }
        return 0;
    }


    public void Reset()
    {
        for(int i = 0; i<Stages; i++)
        {
            this.gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
