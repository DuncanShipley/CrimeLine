using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCursor2 : MonoBehaviour
{
    public Animator carSpin;

    public void SpinTrue()
    {
        carSpin.SetBool("ButtonHighlight", true);
    }
    public void SpinFalse()
    {
        carSpin.SetBool("ButtonHighlight", false);
    }

}
