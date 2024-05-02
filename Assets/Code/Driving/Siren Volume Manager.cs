using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenVolumeManager : MonoBehaviour
{

    public AudioSource Siren;
    public AudioSource Music;

    private float musicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Siren.volume = 0;
        Music.volume = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.currentTime == "00:30.00"){
            Siren.Play();
            Siren.volume = 1;
            Music.volume = 1/2;
        }
    }
}
