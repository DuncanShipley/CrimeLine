using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{ 
    InkExternalFunctions IKF;
    public List<GameObject> CharacterList = new List<GameObject>();
    public string ActiveSpeaker;
    public string ActiveEmotion;
     void Awake()
    {
         IKF = GameObject.FindGameObjectWithTag("Ink External Functions").GetComponent<InkExternalFunctions>();
    }
    void Start()
    {
       
        for (int i = 0; i < characters.Length; i++)
        {
            GameObject newCharacter = Instantiate(characters[i], new Vector3(0, 0, 3), Quaternion.identity);
            newCharacter.transform.SetParent(canvas.transform, false);
            newCharacter.SetActive(false);
            newCharacter.name = characters[i].name;
            CharacterList.Add(newCharacter);
        }
    }


    public void SetSpeaker(){
        if(IKF.CurrentSpeaker!=""){
            if(ActiveSpeaker != IKF.CurrentSpeaker){
                Debug.Log("Setting Speaker to " + IKF.CurrentSpeaker);
                  foreach (GameObject gO in CharacterList){
                    if(gO.name != IKF.CurrentSpeaker){
                        gO.SetActive(false);
                  }
                    if(gO.name == IKF.CurrentSpeaker){
                        gO.transform.SetParent(canvas.transform, true);
                        gO.SetActive(true);
                        ActiveSpeaker = IKF.CurrentSpeaker;
                    }
                }
            }
        }
    }

    public void SetEmotion(){
        if(IKF.CurrentEmotion!="")
        if(ActiveEmotion != IKF.CurrentEmotion){
        Debug.Log("Setting Emotion to " + IKF.CurrentEmotion);
        ActiveEmotion = IKF.CurrentEmotion;
        }
    }


    [SerializeField]
    public GameObject[] characters;

    [SerializeField]
    public Canvas canvas;    
    
    /*public List<GameObject> ActorsList = new List<GameObject>();
    [SerializeField]
    Vector3 leftActorPosition, rightActorPosition;
    List<Emotions> activeActors = new List<Emotions>(); 

    // Start is called before the first frame update
    void Start()
    {
        for(int i  = 0; i < characters.Length; i++)
        {
            GameObject newActor = Instantiate(characters[i]);
            newActor.SetActive(false);
            newActor.name = characters[i].name;
            ActorsList.Add(newActor);
        }
    }

    public void PlaceActors(string leftActorName, string rightActorName)
    {

        foreach (GameObject gO in ActorsList)
        {
            if (gO.name == leftActorName)
            {
                gO.SetActive(true);
                gO.GetComponent<Actor>().ID = 0;
                activeActors.Add(gO.GetComponent<Actor>());
                gO.transform.position = leftActorPosition;
            }
            else if (gO.name == rightActorName)
            {
                gO.SetActive(true);
                gO.GetComponent<Actor>().ID = 1;
                activeActors.Add(gO.GetComponent<Actor>());
                gO.transform.position = rightActorPosition;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    // Emotion can only be angry, sad, happy, or neutral
    //Id left = 0, right = 1
    public void ChangeActorEmotion(string emotion, int ID)
    {
        foreach(Actor actor in activeActors)
        {
            if (actor.gameObject.activeInHierarchy)
            {
                if (actor. ID == ID)
                {
                    actor.changestate(emotion);
                }
            }
        }
    }*/
}
