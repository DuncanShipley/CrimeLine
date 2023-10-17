using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keycode : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player"){
            keys heldKeysScript = GameObject.Find("Player").GetComponent<keys>();
            heldKeysScript.addKey();
            Destroy(gameObject);
        }
    }
}
