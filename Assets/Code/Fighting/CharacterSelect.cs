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

    [SerializeField] private GameObject Ch1Description;
    [SerializeField] private GameObject Ch2Description;
    [SerializeField] private GameObject Ch3Description;
    [SerializeField] private GameObject Ch4Description;
    [SerializeField] private GameObject Ch5Description;
    [SerializeField] private GameObject Ch6Description;
    [SerializeField] private GameObject Ch7Description;
    [SerializeField] private GameObject Ch8Description;

    [SerializeField] private GameObject characterSelect;

    public bool characterSelected = false;

    void Start()
    {
        characterSelect.SetActive(true);
        PointerExit1();
        PointerExit2();
    }
    public void Clicked1()
    {
        Character1.SetActive(true);
        Character2.SetActive(false);
        characterSelected = true;
    }

    public void Clicked2()
    {
        Character2.SetActive(true);
        Character1.SetActive(false);
        characterSelected = true;
    }

    public void PointerEnter1()
    {
        Ch1Description.SetActive(true);
    }
    public void PointerExit1()
    {
        Ch1Description.SetActive(false);
    }
    public void PointerEnter2()
    {
        Ch2Description.SetActive(true);
    }
    public void PointerExit2()
    {
        Ch2Description.SetActive(false);
    }
}
