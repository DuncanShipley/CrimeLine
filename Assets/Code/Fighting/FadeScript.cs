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

    [SerializeField] private CanvasGroup intro;
    [SerializeField] private CanvasGroup blackBackground;
    [SerializeField] private CanvasGroup round;
    [SerializeField] private CanvasGroup fight;

    [SerializeField] private bool fadeInIntro = false;
    [SerializeField] private bool fadeOutIntro = false;
    [SerializeField] private bool fadeInBlackBackground = false;
    [SerializeField] private bool fadeOutBlackBackground = false;
    [SerializeField] private bool fadeInRound = false;
    [SerializeField] private bool fadeOutRound = false;
    [SerializeField] private bool fadeInFight = false;
    [SerializeField] private bool fadeOutFight = false;

    public bool ShowUI(CanvasGroup canvy, bool fadeIn, float speed)
    {
        if (canvy.alpha < 1)
        {
            canvy.alpha += speed*Time.deltaTime;
            if (canvy.alpha >= 1)
            {
                fadeIn = false;
                return fadeIn;
            }
        }
        return true;
    }

    public bool HideUI(CanvasGroup canvy, bool fadeOut, float speed)
    {
        if (canvy.alpha >= 0)
        {
            canvy.alpha -= speed*Time.deltaTime;
            if (canvy.alpha == 0)
            {
                fadeOut = false;
                return fadeOut;
            }
        }
        return true;
    }

    private IEnumerator SpawnDelay()
    {
        fadeOutRound = true;
        fadeOutFight = true;
        yield return new WaitForSeconds(2);
        fadeOutIntro = true;
        yield return new WaitForSeconds(0.3f);
        fadeOutBlackBackground = true;
        yield return new WaitForSeconds(0.3f);
        fadeInRound = true;
        yield return new WaitForSeconds(1f);
        fadeOutRound = true;
        yield return new WaitForSeconds(0.1f);
        fadeInFight = true;
        yield return new WaitForSeconds(1f);
        fadeOutFight = true;
    }

    void Start()
    {
        blackBackgroundObject.SetActive(true);
        introObject.SetActive(true);
        roundObject.SetActive(true);
        fightObject.SetActive(true);
        StartCoroutine(SpawnDelay());
    }

    void Update()
    {
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
    }
}