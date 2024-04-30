using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emotions : MonoBehaviour
{
    //needs a happy, sad, nuetral, and angry sprite for each character
    public Sprite[] emotionSprite;
    SpriteRenderer spRend;
       
    //Add Emotions Here
    public enum CharacterEmotions
    {
        happy,sad,nuetral,angry,annoyed
    }

    [SerializeField] CharacterEmotions Mystate;
      
   
    void Awake()
    {
        Mystate = CharacterEmotions.nuetral;
        spRend = GetComponent<SpriteRenderer>();
    }
    public void changestate(string emotionName)
    {
        Debug.Log("changing emotions");
        StartCoroutine(emotionName + "State");
    }
    IEnumerator NuetralState()
    {
        spRend.sprite = emotionSprite[0];
        Mystate = CharacterEmotions.nuetral;
        yield return null;
    }
    IEnumerator HappyState()
    {
        spRend.sprite = emotionSprite[1];
        Mystate = CharacterEmotions.happy;
        yield return null;
    }
    IEnumerator AngryState()
    {
        spRend.sprite = emotionSprite[2];
        Mystate = CharacterEmotions.angry;
        yield return null;
    }

    IEnumerator SadState()
    {
        spRend.sprite = emotionSprite[3];
        Mystate = CharacterEmotions.sad;
        yield return null;
    }

    IEnumerator AnnoyedState()
    {
        spRend.sprite = emotionSprite[4];
        Mystate = CharacterEmotions.annoyed;
        yield return null;
    }
}
