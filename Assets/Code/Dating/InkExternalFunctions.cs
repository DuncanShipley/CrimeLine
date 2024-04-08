using Ink.Runtime;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkExternalFunctions : MonoBehaviour 
{
    public string CurrentSpeaker;
    public string CurrentEmotion;
    /// <summary>
    /// Binds Ink functions
    /// </summary>
    /// <param name="story"></param>
    public void Bind(Story story)
    {
        Debug.Log("Binding Functions");
        story.BindExternalFunction("SetCharacter", (string CurrentCharacter) => {
            CurrentSpeaker = CurrentCharacter;
        });
       
        story.BindExternalFunction("SetEmotion", (string Emotion) => { 
            CurrentEmotion=Emotion;
        });
    }
    

    /// <summary>
    /// UnBinds Ink functions
    /// </summary>
    /// <param name="story"></param>
    public void unBind(Story story)
    {
        Debug.Log("Unbinding Functions");
        story.UnbindExternalFunction("SetCharacter");
        story.UnbindExternalFunction("SetEmotion");
    }
}
