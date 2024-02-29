using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] characters;
    public List<GameObject> CharacterList = new List<GameObject>();
    private List<Emotions> EmotionalState = new List<Emotions>();
    private List<GameObject> ActiveCharcters = new List<GameObject>();
    void Start()
    {
       
        for (int i = 0; i < characters.Length; i++)
        {
            GameObject newCharacter = Instantiate(characters[i]);
            newCharacter.SetActive(false);
            newCharacter.name = characters[i].name;
            CharacterList.Add(newCharacter);
        }
    }



  
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
