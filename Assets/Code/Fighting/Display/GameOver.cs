using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject youWinMain;
    public GameObject youWinGhost;
    public GameObject youLoseMain;
    public GameObject youLoseGhost;
    public Slider playerHealthSlider;
    public Slider enemyHealthSlider;
    private bool ran = false;

    public FadeScript fadeScript;

    [SerializeField] private AudioClip funny;
    [SerializeField] private AudioClip lore;
    [SerializeField] private AudioClip quadaldiggle;

    private IEnumerator gameWon()
    {
        yield return new WaitForSeconds(0.5f);
        MusicManager.instance.EndSong();
        SFXManager.instance.PlaySFXClip(quadaldiggle, transform, 0.4f);
        yield return new WaitForSeconds(2.5f);
        SFXManager.instance.PlaySFXClip(lore, transform, 0.07f);

        for (int i = 0; i < 25; i++)
        {
            youWinMain.SetActive(true);
            yield return new WaitForSeconds(0.03f);
            youWinMain.SetActive(false);
            youWinGhost.SetActive(true);
            yield return new WaitForSeconds(0.03f);
            youWinGhost.SetActive(false);
        }
        yield return new WaitForSeconds(10f);
        MusicManager.instance.PlaySong(funny, transform, 0.07f);
    }
    private IEnumerator gameLost()
    {
        yield return new WaitForSeconds(3.5f);
        for (int i = 0; i < 25; i++)
        {
            youLoseMain.SetActive(true);
            yield return new WaitForSeconds(0.03f);
            youLoseMain.SetActive(false);
            youLoseGhost.SetActive(true);
            yield return new WaitForSeconds(0.03f);
            youLoseGhost.SetActive(false);
        }
    }

    void Update()
    {
        if (enemyHealthSlider.value <= 0)
        {
            if (!ran)
            {
                StartCoroutine(gameWon());
                fadeScript.allowAction = false;
                ran = true;
            }
        }
        if (playerHealthSlider.value <= 0)
        {
            if (!ran)
            {
                StartCoroutine(gameLost());
                fadeScript.allowAction = false;
                ran = true;
            }
        }
    }
}
