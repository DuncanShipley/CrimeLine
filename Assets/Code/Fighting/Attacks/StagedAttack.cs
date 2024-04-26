using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StagedAttack : MonoBehaviour
{
    public virtual GameObject[] Stages {get; set;}

    public void Awake()
    {
        Reset();
        Stages[0].SetActive(true);
    }

    public void NextStage()
    {
        int FirstActive = FindFirstAcive(Stages);
        if (FirstActive == Stages.Length)
        {
            Reset();
            return;
        }
        Stages[FirstActive].SetActive(false);
        Stages[FirstActive+1].SetActive(true);
    }

    public int FindFirstAcive(GameObject[] gameObects)
    {
        int count = 0;
        foreach(var Object in gameObects)
        {
            if (Object.activeSelf)
            {
                return count;
            }
            count++;
        }
        return -1;
    }

    public void Reset()
    {
        foreach(var Object in Stages)
        {
            Object.SetActive(false);
        }
    }
}
