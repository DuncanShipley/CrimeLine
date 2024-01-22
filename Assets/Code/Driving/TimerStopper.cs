using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerStopper : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        EventManager.OnTimerStop();
        print("You Win!");
        SceneManager.LoadScene("You Win!");
    }
}
