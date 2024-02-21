using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class movescriptA : MonoBehaviour
{
    GameObject copy;
    public GameObject projectile;
    Vector3 lastInput;
    float h = 0f;
    float v = 0f;
    float throwPause = 0;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameObject.Find("Panel").GetComponent<PanelPuzzleA>().isActivated())
        {

            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");

            //movement
            var rb = GetComponent<Rigidbody2D>();
            var spd = 5;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                spd = 12;
            }

            Vector3 inp = new Vector3(h / spd, v / spd, 0);
            rb.MovePosition(transform.position + inp);

            if (Math.Abs(h) > Math.Abs(v))
            {
                if (h > 0)
                {
                    anim.SetInteger("playerDir", 2);
                }
                else if(h < 0)
                {
                    anim.SetInteger("playerDir", 4);
                }
            }
            else if ((Math.Abs(v) >= Math.Abs(h)) && (Math.Abs(v) != 0))
            {
                if (v > 0)
                {
                    anim.SetInteger("playerDir", 1);
                }
                else if (v < 0)
                {
                    anim.SetInteger("playerDir", 3);
                }
            }
            else
            {
                anim.SetInteger("playerDir", 0);
            }
        }
        
    }
}
