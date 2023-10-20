using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keycodeT : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("keycard").GetComponent<Canvas>().enabled = false;
        //Debug.Log(GameObject.Find("keycard").GetComponent<Canvas>().enabled);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player"){
            keysT heldKeysScript = GameObject.Find("Player").GetComponent<keysT>();
            heldKeysScript.addKey();
            GameObject.Find("keycard").GetComponent<Canvas>().enabled = true;
            Destroy(gameObject);
        }
    }
}
