using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keycodeA : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("keycard").GetComponent<Canvas>().enabled = false;
        Debug.Log(GameObject.Find("keycard").GetComponent<Canvas>().enabled);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player"){
            keys heldKeysScript = GameObject.Find("Player").GetComponent<keys>();
            heldKeysScript.addKey();
            GameObject.Find("keycard").GetComponent<Canvas>().enabled = true;
            Destroy(gameObject);
        }
    }
}