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
    void Awake()
    {  
        cm = GetComponent<CharacterManager>();
        gm = GetComponent<GameManager>();
        IKF = GameObject.FindGameObjectWithTag("Ink External Functions").GetComponent<InkExternalFunctions>();
        bgm = GameObject.FindGameObjectWithTag("Background").GetComponent<BackgroundManager>();
        Debug.Log("Starting Story");
        story = new Story(inkJSONAsset.text);
        IKF.Bind(story);
        RefreshView();
    }
    private void Update()
    {
        // Displays a new line every time you click unless there is a choice 
        if (counting == 0){
            if (story.canContinue == true) { 
                if (story.currentChoices.Count == 0){   
                    if (Input.GetMouseButtonDown(0))
                    {
                        RefreshView();
                    }
                }   
            }
        }
        if(counting !=0)
        {
            if(Input.GetMouseButtonDown(1)){ skippedPressed = true;}
        }
    }
   /// <summary>
   /// Main Function, Destroys old content and choices. Creates new line of dialouge and any choices
   /// </summary>
    void RefreshView()
    {
        RemoveText();
        RemoveButtons();
        //Displays one line of text at a time
        if(story.canContinue==true) {StartCoroutine(DisplayLine(story.Continue()));}
        if(IKF.CurrentBackground != ""){bgm.changeBackground(IKF.CurrentBackground);}
        if(IKF.CurrentSpeaker != ""){cm.SetSpeaker();}
        if(IKF.CurrentEmotion != ""){ cm.SetEmotion();}
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
             StartCoroutine(DisplayLine("You have reached the end of the story, there are no more choices. You will start the fighting or stealth section now."));
            }
        }            
    }
    private IEnumerator DisplayLine(string line)
    {
        string text = "";
        RemoveText();
        foreach(char letter in line.ToCharArray())
        {
            if (skippedPressed == true)  
            {
                text = line;
                RemoveText();
                CreateContentView(text);
                skippedPressed = false;
                counting = 0;
                break;
            }
            counting++;
            text += letter;
            CreateContentView(text);
            if(counting == line.Length){counting =0;}
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // When we click the choice button, tell the story to choose that choice!
    void OnClickChoiceButton (Choice choice) {
		story.ChooseChoiceIndex(choice.index);
		RefreshView();
	}

   /// <summary>
   /// Creates a text box and displays the dialouge
   /// </summary>
   /// <param name="text"></param>
    void CreateContentView(string text)
    {
        if(text==""){
            RefreshView();
        }
        StoryText = Instantiate(textPrefab, new Vector3(-30f, 120f, 1), Quaternion.identity) as TextMeshProUGUI;
        StoryText.text = text;
        RemoveText();
        StoryText.transform.SetParent(canvas.transform, false); 
    }

    // Creates a button showing the choice 
    Button CreateChoiceView(string text)
    {
     // Creates the button from a prefab
     Button choice = Instantiate(buttonPrefab, new Vector3(450, -285-(BP*TR), 1), Quaternion.identity) as Button;
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
/// Sets the current line blank
/// </summary>
/// <param name="line"></param>
    void SetBlank(string line){
        line = "";
    }

    /// <summary>
    /// Removes UI from the Ink canvas
    /// </summary>
    void RemoveText()
    {
        int childCount = canvas.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            if(canvas.transform.GetChild(i).gameObject.name == "Text(Clone)"){
                Destroy(canvas.transform.GetChild(i).gameObject);
            }
        }
    }

    void RemoveButtons(){
         int childCount = canvas.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i)
        {
            if(canvas.transform.GetChild(i).gameObject.name == "Button(Clone)"){
            Destroy(canvas.transform.GetChild(i).gameObject);
            }
        }
    }

    [SerializeField] private TextAsset inkJSONAsset;
    [SerializeField] private Canvas canvas;
    [SerializeField] private TextMeshProUGUI textPrefab;
    [SerializeField] private Button buttonPrefab;
    [SerializeField] private float typingSpeed = 0.04f;
    public Story story;
    private string line;
    private TextMeshProUGUI StoryText;
    private bool skippedPressed;
    private int counting;
    private int BP = 0;
    private int TR = 0;
    GameManager gm;
    CharacterManager cm;
    InkExternalFunctions IKF;
    BackgroundManager bgm;
}