using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPuzzleAlexis : MonoBehaviour
{
    private PanelPuzzleAlexis puzzle;
    private InputControllerAlexis input;

    private bool puzzleDone = false;
    private bool touch = false;

    // Start is called before the first frame update
    void Start()
    {
        puzzle = GameObject.Find("Panel").GetComponent<PanelPuzzleAlexis>();
        input = GameObject.Find("Screen UI").GetComponent<InputControllerAlexis>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.GetKeyLimited("z") && touch && !puzzleDone)
        {
            puzzle.activate();
            puzzleDone = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            touch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touch = false;
    }
}
