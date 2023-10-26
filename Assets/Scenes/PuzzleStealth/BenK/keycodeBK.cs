using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keycodeBK : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("keycard").GetComponent<Canvas>().enabled = false;
        Debug.Log(GameObject.Find("keycard").GetComponent<Canvas>().enabled);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player"){
            keysBK heldKeysScript = GameObject.Find("Player").GetComponent<keysBK>();
            heldKeysScript.addKey();
            GameObject.Find("keycard").GetComponent<Canvas>().enabled = true;
            Destroy(gameObject);
        }
    }
}
