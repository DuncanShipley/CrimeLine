using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keycodeT : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("keycardSprite").GetComponent<Image>().enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player"){
            PanelPuzzleT PanelPuzzle = GameObject.Find("Panel").GetComponent<PanelPuzzleT>();
            PanelPuzzle.activate();
            
            Destroy(gameObject);
        }
    }
}
