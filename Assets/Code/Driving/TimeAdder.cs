using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    AudioSource source;
    [SerializeField] private GameObject stopwatch;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        EventManager.OnTimerUpdate(30);
        source.Play();

        stopwatch.GetComponent<Renderer>().enabled = false;

        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
