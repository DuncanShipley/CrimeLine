using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
public class Dialouge : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] Lines;
    public float textspeed;

    [SerializeField]
    private TextAsset inkJsonAsset;
    private Story story;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        story = new Story(inkJsonAsset.text);
       // textComponent.text = Lines;
        StartDialouge();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == Lines[index])
            {
                NextLine();
            }
             else
            {
             StopAllCoroutines();
                textComponent.text = Lines[index];
            }
        }
    }

    void StartDialouge()
    {
        index = 0;
        StartCoroutine(TypeLine());

        while (story.canContinue)

        {
            // Continue gets the next line of the story
            string text = story.Continue();
            // This removes any white space from the text.
            text = text.Trim();
            // Display the text on screen
        }
    }
    IEnumerator TypeLine()
    {
        //Type Each Character 1 by 1
        foreach (char c in Lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textspeed);
        }
    }
    void NextLine()
    {
        if (index < Lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
           StartDialouge();
        }
    }
}
