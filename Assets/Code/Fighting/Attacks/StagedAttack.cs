using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StagedAttack : MonoBehaviour
{
    public virtual GameObject[] Stages {get; set;}

    public void Start()
    {
        foreach(Object in Stages)
        {
            Object.SetActive(false);
        }
        
    }
}
