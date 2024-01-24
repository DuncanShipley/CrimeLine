using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterSelect : MonoBehaviour
{
    [SerializeField] private GameObject Character1;
    [SerializeField] private GameObject Character2;
    [SerializeField] private GameObject Character3;
    [SerializeField] private GameObject Character4;
    [SerializeField] private GameObject Character5;
    [SerializeField] private GameObject Character6;
    [SerializeField] private GameObject Character7;
    [SerializeField] private GameObject Character8;

    public bool characterSelected = false;

    public void Clicked1()
    {
        Character2.SetActive(false);
        characterSelected = true;
    }

    public void Clicked2()
    {
        Character1.SetActive(false);
        characterSelected = true;
    }
}
