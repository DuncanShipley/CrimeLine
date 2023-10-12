using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    //needs a happy, sad, nuetral, and angry sprite for each character
    public Sprite[] emotionSprite;
    SpriteRenderer spRend;
    public int ID; // left = 0. right = 1
   public enum CharcterEmotions
    {
        happy,sad,nuetral,angry
    }

    [SerializeField]
    CharcterEmotions Mystate;
      
   
    void Awake()
    {
        Mystate = CharcterEmotions.nuetral;
        spRend = GetComponent<SpriteRenderer>();
    }
    public void changestate(string emotionName)
    {
        StartCoroutine(emotionName + "State");
    }
    IEnumerator NuetralState()
    {
        spRend.sprite = emotionSprite[0];
        myState = CharacterEmotion;
        yield return null;
    }
    IEnumerator HappyState()
    {
        spRend.sprite = emotionSprite[1];
        yield return null;
    }
    IEnumerator AngryState()
    {
        spRend.sprite = emotionSprite[2];
        yield return null;
    }
    IEnumerator SadState()
    {
        spRend.sprite = emotionSprite[3];
        yield return null;
    }

}
