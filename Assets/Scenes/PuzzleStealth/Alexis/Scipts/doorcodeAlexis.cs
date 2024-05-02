using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorcodeAlexis : MonoBehaviour
{
    public string lockType;
    public int keyID;
    public string dir;

    private KeychainAlexis keychain;
    private bigTextboxAlexis textbox;

    bool faceActive = false;
    bool touch = false;
    bool open = false;
    bool opening = false;
    float movequeue = 0;
    float speed = 10;
    private InputControllerAlexis input;

    // Colider
    private void Start()
    {
        input = GameObject.Find("Screen UI").GetComponent<InputControllerAlexis>();
        keychain = GameObject.Find("Player").GetComponent<KeychainAlexis>();
        textbox = GameObject.Find("bigTextbox").GetComponent<bigTextboxAlexis>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player"){
            touch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        touch = false;
    }

    private void Update()
    {

        if (input.GetKeyLimited("z") && touch && movequeue == 0 && !opening)
        {
            switch (lockType)
            {
                case "key":
                    if (keychain.getKeys() >= keyID)
                    {
                        if (open)
                        {
                            open = false;
                        }
                        else
                        {
                            open = true;
                        }
                        movequeue += 10;
                        opening = true;
                    }
                    else if (!textbox.isTalking())
                    {
                        textbox.pushText(new string[] { "It's locked. You need a key to open this." });
                    }
                    break;

                case "faceID":
                    if (faceActive)
                    {
                        if (open)
                        {
                            open = false;
                        }
                        else
                        {
                            open = true;
                        }
                        movequeue += 10;
                        opening = true;
                    }
                    else if (!textbox.isTalking())
                    {
                        textbox.pushText(new string[] { "It's locked. It seems like this door needs facial recognition to open" });
                    }
                    break;

                default:
                    if (open)
                    {
                        open = false;
                    }
                    else
                    {
                        open = true;
                    }
                    movequeue += 10;
                    opening = true;
                    break;
            }
            
            
        }

        if (movequeue != 0)
        {
            var rb = GetComponent<Rigidbody2D>();
            var x = 0;
            var y = 0;

            switch (dir)
            {
                case "up":
                    if (open)
                        y++;
                    else
                        y--;
                    break;

                case "down":
                    if (open)
                        y--;
                    else
                        y++;
                    break;

                case "right":
                    if (open)
                        x++;
                    else
                        x--;
                    break;

                case "left":
                    if (open)
                        x--;
                    else
                        x++;
                    break;

                default:
                    break;
            }

            Vector3 inp = new Vector3(x / speed, y / speed, 0);
            transform.position = transform.position + inp;
            movequeue--;

            if (movequeue == 0)
                opening = false;
        }
    }

    public void updateFaceID(bool active)
    {
        faceActive = active;
    }
}
