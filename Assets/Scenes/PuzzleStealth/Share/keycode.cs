using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keycode : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("keycardSprite").GetComponent<Image>().enabled = false;
        Debug.Log(GameObject.Find("keycardSprite").GetComponent<Image>().enabled);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player"){
            PanelPuzzle PanelPuzzle = GameObject.Find("Panel").GetComponent<PanelPuzzle>();
            PanelPuzzle.activate();
            
            Destroy(gameObject);
        }
    }
}
