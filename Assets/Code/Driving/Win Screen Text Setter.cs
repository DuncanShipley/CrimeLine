using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScreenTextSetter : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _timeText;

    void Start()
    {
        _timeText.text = "You had " + Timer.currentTime + " left!";
    }
}
