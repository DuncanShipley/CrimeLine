using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class characterSelectorMain : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    private TextMeshProUGUI characterName;
    private MovescriptMain player;
    private itemSelectorMain inv;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<MovescriptMain>();
        characterName = GameObject.Find("characterName").GetComponent<TextMeshProUGUI>();

        inv = GameObject.Find("IScursor").GetComponent<itemSelectorMain>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chooseCharacter(GameObject button)
    {
        if(button == button1) 
        {
            player.baseSpeed = 4;
            characterName.SetText("Acrobat");
        }
        else if(button == button2) 
        {
            characterName.SetText("Assasin");
            inv.AddItem(GameObject.Find("knife"));
        }
        else if(button == button3) 
        {
            characterName.SetText("Technician");
            inv.AddItem(GameObject.Find("signalJammer"));
            
        }

        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
    }
}
