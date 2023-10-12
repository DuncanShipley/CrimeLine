using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    //needs a happy, sad, nuetral, and angry sprite for each character
    public Sprite[] emotionSprite;
    SpriteRenderer spRend;
    public int ID; // left = 0. right = 1
   public enum CharacterEmotions
    {
        happy,sad,nuetral,angry
    }

    [SerializeField]
    CharacterEmotions Mystate;
      
   
    void Awake()
    {
        Mystate = CharacterEmotions.nuetral;
        spRend = GetComponent<SpriteRenderer>();
    }
    public void changestate(string emotionName)
    {
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
}
