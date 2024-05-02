using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCursor2 : MonoBehaviour
{
    public Animator carSpin;

    public void CyberTruckSpinTrue()
    {
        carSpin.SetBool("ButtonHighlight", true);
    }
    public void CyberTruckSpinFalse()
    {
        carSpin.SetBool("ButtonHighlight", false);
    }

}
