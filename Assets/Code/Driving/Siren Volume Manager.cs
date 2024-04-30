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
        Music.volume = 1;
        Siren.volume = 0;
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
