using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using Unity.VisualScripting;
using TMPro;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

public class InkManager : MonoBehaviour
{
    private InkExternalFunctions InkExternalFunctions;
    void Awake()
    {
        // Remove the default message
        cm = GetComponent<CharacterManager>();
        gm = GetComponent<GameManager>();
        InkExternalFunctions = new InkExternalFunctions();
        StartStory();
       
       
    }

    private void Update()
    {
        // Displays a new line every time you click unless there is a choice 
        if (story.canContinue == true) { 
            if (story.currentChoices.Count == 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    RefreshView();
                }
            }
        }
    }

    // Creates a new Story object with the compiled story which we can then play!
    void StartStory()
    {
        story = new Story(inkJSONAsset.text);
        InkExternalFunctions.Bind(story);
        RefreshView();
    }

   
    
   /// <summary>
   /// Main Function, Destroys old content and choices. Creates new line of dialouge and any choices
   /// </summary>
    void RefreshView()
    {
        
        RemoveChildren();
        //Displays one line of text at a time
        int LD = 1;
        while (LD != 0)
        {
           
            if (story.canContinue==true) {
                // Continue gets the next line of the story
                 string text = story.Continue();
                 // This removes any white space from the text.
                 text = text.Trim();
                 // Display the text on screen!
                 CreateContentView(text);
               LD --;
            }
        }

        if (InkExternalFunctions.CurrentSpeaker != "")
        {
            cm.SetSpeaker();
        }

        // Display all the choices, if there are any!
        if (story.currentChoices.Count > 0)
        {
            BP = 0; 
            TR = 0;
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                Button button = CreateChoiceView(choice.text.Trim());
                // Tell the button what to do when we press it
                button.onClick.AddListener(delegate {
                    OnClickChoiceButton(choice);
                });
            }
        }
        if (story.canContinue==false)
        {
            if(story.currentChoices.Count == 0)
            {
             print("No more choices");
            }
        }            
    }


    // When we click the choice button, tell the story to choose that choice!
    void OnClickChoiceButton (Choice choice) {
		story.ChooseChoiceIndex (choice.index);
		RefreshView();
	}

   /// <summary>
   /// Creates a text box and displays the dialouge
   /// </summary>
   /// <param name="text"></param>
    void CreateContentView(string text)
    {
        TextMeshProUGUI storyText = Instantiate(textPrefab, new Vector3(120f, 150f, 0), Quaternion.identity) as TextMeshProUGUI;
        storyText.text = text;
        storyText.transform.SetParent(canvas.transform, false);
        print(storyText.text);
    }


    //moves the button down 35 units on the y axis
    public static int BP = 0;
    //the amount of buttons being created 
    public static int TR = 0;
    // Creates a button showing the choice 
    Button CreateChoiceView(string text)
    {
     // Creates the button from a prefab
     Button choice = Instantiate(buttonPrefab, new Vector3(425, -235-(BP*TR), 0), Quaternion.identity) as Button;
     choice.transform.SetParent(canvas.transform, false);

        // Gets the text from the button prefab
        Text choiceText = choice.GetComponentInChildren<Text>();
        choiceText.text = text;
        choiceText.color = Color.black; 

     // Make the button expand to fit the text
     HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
     layoutGroup.childForceExpandHeight = false;
     BP=30;
     TR++;

     return choice;
     }

    /// <summary>
    /// Removes UI from the Ink canvas
    /// </summary>
    void RemoveChildren()
    {
        int childCount = canvas.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            Destroy(canvas.transform.GetChild(i).gameObject);
        }
    }

    [SerializeField]
    private TextAsset inkJSONAsset;
    public Story story;

    [SerializeField]
    private Canvas canvas;

    // UI Prefabs
    [SerializeField]
    private TextMeshProUGUI textPrefab;
    [SerializeField]
    private Button buttonPrefab;
    GameManager gm;
    CharacterManager cm;
    
}