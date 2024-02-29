using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkExternalFunctions
{
    /// <summary>
    /// Binds Ink functions
    /// </summary>
    /// <param name="story"></param>
    public void Bind(Story story)
    {
        story.BindExternalFunction("SetCharcter", (string CurrentSpeaker) => {
            Debug.Log(CurrentSpeaker);
        });

        story.BindExternalFunction("SetEmotion", (string CurrentEmotion) => {
            Debug.Log(CurrentEmotion);
        });
    }

    /// <summary>
    /// Unbinds Ink functions
    /// </summary>
    /// <param name="story"></param>

    public void unBind(Story story)
    {

    }
}
