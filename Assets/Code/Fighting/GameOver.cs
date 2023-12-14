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

    private IEnumerator gameWon()
    {
        yield return new WaitForSeconds(3.5f);
        for (int i = 0; i < 25; i++)
        {
            youWinMain.SetActive(true);
            yield return new WaitForSeconds(0.03f);
            youWinMain.SetActive(false);
            youWinGhost.SetActive(true);
            yield return new WaitForSeconds(0.03f);
            youWinGhost.SetActive(false);
        }
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
                ran = true;
            }
        }
        if (playerHealthSlider.value <= 0)
        {
            if (!ran)
            {
                StartCoroutine(gameLost());
                ran = true;
            }
        }
    }
}
