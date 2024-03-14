using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class movescriptA : MonoBehaviour
{
    float h = 0f;
    float v = 0f;
    int spd;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CanMove())
        {
            // get the player's current momentum
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");

            spd = GetSpeed();

            // movement
            MakeMovement(h, v);

            // animation
            SetMovementAnim();
        }
        
    }

    void SetMovementAnim()
    {
        if (Math.Abs(h) > Math.Abs(v))
        {
            if (h > 0)
            {
                anim.SetInteger("playerDir", 2);
            }
            else if (h < 0)
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

    void MakeMovement(float hv, float vv)
    {
        var rb = GetComponent<Rigidbody2D>();
        Vector3 inp = new Vector3(hv / 20 * spd, vv / 20 * spd, 0);
        rb.MovePosition(transform.position + inp);
    }

    int GetSpeed()
    {
        // set speed based on if the player if Focused or not
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return 2;
        }
        else
        {
            return 4;
        }
    }

    bool CanMove()
    {
        if((Input.GetKey(KeyCode.C)))
        {
            return false;
        }
        return true;
    }

}
