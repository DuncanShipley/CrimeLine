using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScriptTest : MonoBehaviour
{
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
    [SerializeField] private Slider slider;
    //private HealthScript p1health;
    //private HealthScript p2health;

    public bool ShowUI(CanvasGroup canvy, bool fadeIn)
    {
        if (canvy.alpha < 1)
        {
            canvy.alpha += Time.deltaTime;
            if (canvy.alpha >= 1)
            {
                fadeIn = false;
                return fadeIn;
            }
        }
            return true;

    }

    public bool HideUI(CanvasGroup canvy, bool fadeOut)
    {
        if (canvy.alpha >= 0)
        {
            canvy.alpha -= Time.deltaTime;
            if (canvy.alpha == 0)
            {
                fadeOut = false;
                return fadeOut;
            }
        }
            return true;
    }

    void Start()
    {
        fadeOutIntro = true;
        fadeOutBlackBackground = true;
        fadeInRound = true;
        fadeInFight = true;
        //p1health = p1.GetComponent<HealthScript>();
        //p2health = p2.GetComponent<HealthScript>();
    }

    void Update()
    {
        //if (p2health.slider.value == 0f)
        //{

        //}
        if (fadeInIntro)
        {
            fadeInIntro = ShowUI(intro, fadeInIntro);
        }
        if (fadeOutIntro)
        {
            fadeOutIntro = HideUI(intro, fadeOutIntro);
        }
        if (fadeInBlackBackground)
        {
            fadeInBlackBackground = ShowUI(blackBackground, fadeInBlackBackground);
        }
        if (fadeOutBlackBackground)
        {
            fadeOutBlackBackground = HideUI(blackBackground, fadeOutBlackBackground);
        }
        if (fadeInRound)
        {
            fadeInRound = ShowUI(round, fadeInRound);
        }
        if (fadeOutRound)
        {
            fadeOutRound = HideUI(round, fadeOutRound);
        }
        if (fadeInFight)
        {
            fadeInFight = ShowUI(fight, fadeInFight);
        }
        if (fadeOutFight)
        {
            fadeOutFight = HideUI(fight, fadeOutFight);
        }
    }
}
