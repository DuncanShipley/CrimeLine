using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StagedAttack : MonoBehaviour
{
    //todo get something      dun dun dun dun dun dun dun dun dun dun dun dn dun dun dun dun dun dun dun dun 

    public virtual int Stages {get; set;}

    public void Awake()
    {
        Reset();
        GetChildAt(0).SetActive(true);
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
        GetChildAt(stage).SetActive(false);
        GetChildAt(stage+1).SetActive(true);
        Invoke("NextStage", 1);
    }

    public int FindStage(int stages)
    {

        for(int i = 0; i<stages; i++)
        {
            if (GetChildAt(i).activeSelf)
            {
                return i;
            }

        }
        return 0;
    }

    ref GameObject GetChildAt(int i)
    {
        ref GameObject child = this.gameObject.transform.GetChild(i).gameObject;
        return ref child;
    }

    public void Reset()
    {
        for(int i = 0; i<Stages; i++)
        {
            GetChildAt(i).SetActive(false);
        }
    }
}
