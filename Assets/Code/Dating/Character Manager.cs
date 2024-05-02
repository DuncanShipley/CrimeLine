using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{ 
    InkExternalFunctions IKF;
    public List<GameObject> CharacterList = new List<GameObject>();
    List<GameObject> activeSpeakers = new List<GameObject>();
    private string ActiveSpeaker;
    public string ActiveEmotion;
    [SerializeField] public GameObject[] characters;
    [SerializeField] public Canvas canvas;    
     void Awake()
    {
         IKF = GameObject.FindGameObjectWithTag("Ink External Functions").GetComponent<InkExternalFunctions>();
    }
    void Start()
    {     
        ActiveEmotion = "Nuetral"; 
        for (int i = 0; i < characters.Length; i++){
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
        if(IKF.CurrentEmotion!=""){
            if(ActiveEmotion != IKF.CurrentEmotion){
                Debug.Log("Setting Emotion to " + IKF.CurrentEmotion);
                ActiveEmotion = IKF.CurrentEmotion;
              /*  foreach(gameObject speaker in activeSpeakers){
                    if(speaker.gameObject.activeInHierachy){
                        speaker.changestate(ActiveEmotion);
                    }
                }*/
            }
        }
    }
}