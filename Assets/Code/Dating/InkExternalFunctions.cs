using Ink.Runtime;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkExternalFunctions 
{
    public string CurrentSpeaker;
    public string CurrentEmotion = "Emotion test";
    /// <summary>
    /// Binds Ink functions
    /// </summary>
    /// <param name="story"></param>
    public void Bind(Story story)
    {
        Debug.Log("Binding Functions");
        story.BindExternalFunction("SetCharacter", (string CurrentCharacter) => {
            CurrentSpeaker = CurrentCharacter;
            Debug.Log(CurrentSpeaker);
        });
        Debug.Log(CurrentSpeaker + " attempt 2");

        story.BindExternalFunction("SetEmotion", (string Emotion) => { 
            CurrentEmotion=Emotion;
            Debug.Log(CurrentEmotion);
        });
    }
    

    /// <summary>
    /// Unbinds Ink functions
    /// </summary>
    /// <param name="story"></param>

    public void unBind(Story story)
    {
        Debug.Log("Unbinding Functions");
        story.UnbindExternalFunction("SetCharacter");
        story.UnbindExternalFunction("SetEmotion");
    }
}
