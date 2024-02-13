using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    [SerializeField] private GameObject blackBackgroundObject;
    [SerializeField] private GameObject introObject;
    [SerializeField] private GameObject roundObject;
    [SerializeField] private GameObject fightObject;
    [SerializeField] private GameObject charSelectObject;

    [SerializeField] private CanvasGroup blackBackground;
    [SerializeField] private CanvasGroup intro;
    [SerializeField] private CanvasGroup round;
    [SerializeField] private CanvasGroup fight;
    [SerializeField] private CanvasGroup charSelectCanvasGroup;

    private bool fadeInIntro = false;
    private bool fadeOutIntro = false;
    private bool fadeInBlackBackground = false;
    private bool fadeOutBlackBackground = false;
    [SerializeField] private bool fadeInRound = false;
    [SerializeField] private bool fadeOutRound = false;
    [SerializeField] private bool fadeInFight = false;
    [SerializeField] private bool fadeOutFight = false;
    private bool fadeInCharSelect = false;
    private bool fadeOutCharSelect = false;

    public bool allowAction = false;

    public CharacterSelect characterSelect;

    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip spookyLoop;
    [SerializeField] private AudioClip charSelectBeep;
    private GameObject instantiatedSong;

    public bool ShowUI(CanvasGroup canvy, bool fadeIn, float speed)
    {
        if (canvy.alpha < 1)
        {
            canvy.alpha += speed*0.0025f;
            if (canvy.alpha >= 1)
            {
                return false;
            }
        }
        return true;
    }

    public bool HideUI(CanvasGroup canvy, bool fadeOut, float speed)
    {
        if (canvy.alpha >  0)
        {
            canvy.alpha -= speed*0.0025f;
            if (canvy.alpha == 0)
            {
                 return false;
            }
        }
          return true;
    }

    private IEnumerator SpawnDelay()
    {
        MusicManager.instance.EndSong();
        SFXManager.instance.PlaySFXClip(charSelectBeep, transform, 1f);
        fadeOutRound = true;
        fadeOutFight = true;
        fadeOutCharSelect = true;
        charSelectObject.SetActive(false);
        yield return new WaitForSeconds(2);
        fadeOutIntro = true;
        yield return new WaitForSeconds(0.3f);
        introObject.SetActive(false);
        fadeOutBlackBackground = true;
        yield return new WaitForSeconds(0.3f);
        blackBackgroundObject.SetActive(false);
        fadeInRound = true;
        MusicManager.instance.PlaySong(spookyLoop, transform, 0.35f);
        yield return new WaitForSeconds(1f);
        fadeOutRound = true;
        yield return new WaitForSeconds(0.1f);
        fadeInFight = true;
        yield return new WaitForSeconds(1f);
        fadeOutFight = true;
        allowAction = true;
    }

    void Start()
    {
        MusicManager.instance.PlaySong(menuMusic, transform, 0.08f);
        blackBackgroundObject.SetActive(true);
        introObject.SetActive(true);
        roundObject.SetActive(true);
        fightObject.SetActive(true);
    }

    void Update()
    {
        if (characterSelect.characterSelected)
        {
            StartCoroutine(SpawnDelay());
            characterSelect.characterSelected = false;
        }
        if (fadeInIntro)
        {
            fadeInIntro = ShowUI(intro, fadeInIntro, 2);
        }
        if (fadeOutIntro)
        {
            fadeOutIntro = HideUI(intro, fadeOutIntro, 2);
        }
        if (fadeInBlackBackground)
        {
            fadeInBlackBackground = ShowUI(blackBackground, fadeInBlackBackground, 4);
        }
        if (fadeOutBlackBackground)
        {
            fadeOutBlackBackground = HideUI(blackBackground, fadeOutBlackBackground, 4);
        }
        if (fadeInRound)
        {
            fadeInRound = ShowUI(round, fadeInRound, 4);
        }
        if (fadeOutRound)
        {
            fadeOutRound = HideUI(round, fadeOutRound, 4);
        }
        if (fadeInFight)
        {
            fadeInFight = ShowUI(fight, fadeInFight, 4);
        }
        if (fadeOutFight)
        {
            fadeOutFight = HideUI(fight, fadeOutFight, 4);
        }
        if (fadeInCharSelect)
        {
            fadeInCharSelect = ShowUI(charSelectCanvasGroup, fadeInCharSelect, 4);
        }
        if (fadeOutCharSelect)
        {
            fadeOutCharSelect = HideUI(charSelectCanvasGroup, fadeOutCharSelect, 4);
        }
    }
}
