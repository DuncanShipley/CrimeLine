using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.Fighting.CharacterControl;

public abstract class StagedAttack : MonoBehaviour
{
    //todo get something      dun dun dun dun dun dun dun dun dun dun dun dun dun dun dun dun dun dun dun dun nah nvmd

    public virtual int Stages {get; set;}

    private PlayerActionManager parent;


    public void Awake()
    {
        Set();
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        parent = this.gameObject.transform.parent.GetComponent<PlayerActionManager>();
        Invoke("NextStage", 1);
    }
    
    public void NextStage()
    {
        int stage = FindStage(Stages);
        if (stage == Stages-1)
        {
            parent.setStun(false);
            Destroy(gameObject);
            return;
        }
        gameObject.transform.GetChild(stage).gameObject.SetActive(false);
        gameObject.transform.GetChild(stage+1).gameObject.SetActive(true);
        Invoke("NextStage", 1);
    }

    public int FindStage(int stages)
    {

        for(int i = 0; i<stages; i++)
        {
            if (gameObject.transform.GetChild(i).gameObject.activeSelf)
            {
                return i;
            }

        }
        return 0;
    }


    public void Set()
    {
        for(int i = 0; i<Stages; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        UnityEngine.Debug.unityLogger.Log("PLUHHHHHH");
    }
}
