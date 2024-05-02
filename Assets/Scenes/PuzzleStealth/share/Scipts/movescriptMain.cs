using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class movescriptMain : MonoBehaviour
{
    float h = 0f;
    float v = 0f;
    public float baseSpeed = 3;
    public Rigidbody2D heldObject;
    float spd;

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
            if(MovingObj()) {
                MakeMovementWithObj(h, v);
            } else {
                MakeMovement(h, v);
            }
            

            // animation
            SetMovementAnim();
        }
        
    }

    void SetMovementAnim()
    {
        if (Math.Abs(h) > Math.Abs(v) )
        {
            if ((!MovingObj() && h > 0) || (MovingObj() && heldObject.transform.position.x > transform.position.x))
            {
                anim.SetInteger("playerDir", 2); //right
            }
            else if ((!MovingObj() && h < 0) || (MovingObj() && heldObject.transform.position.x < transform.position.x))
            {
                anim.SetInteger("playerDir", 4); //left
            }
        }
        else if (Math.Abs(v) >= Math.Abs(h) && Math.Abs(v) != 0)
        {
            if ((!MovingObj() && v > 0) || (MovingObj() && heldObject.transform.position.y > transform.position.y))
            {
                anim.SetInteger("playerDir", 1); //up
            }
            else if ((!MovingObj() && v < 0) || (MovingObj() && heldObject.transform.position.y < transform.position.y))
            {
                anim.SetInteger("playerDir", 3); //down
            }
        }
        else
        {
            anim.SetInteger("playerDir", 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="movable"){
            heldObject = other.GetComponentInParent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag=="movable"){
            heldObject = null;
        }
    }

    void MakeMovement(float hv, float vv)
    {
        var rb = GetComponent<Rigidbody2D>();

        Vector3 inp = new Vector3(hv / 20 * spd, vv / 20 * spd, 0);
        rb.MovePosition(transform.position + inp);
    }

    void MakeMovementWithObj(float hv, float vv)
    {
        var rb1 = GetComponent<Rigidbody2D>();
        var rb2 = heldObject;
        Vector3 inp = new Vector3(0, 0, 0);

        if(Math.Abs(transform.position.x - heldObject.transform.position.x) > 0.5) 
        {
            inp = new Vector3(hv / 20 * spd, 0, 0);
        } 
        else if (Math.Abs(transform.position.y - heldObject.transform.position.y) > 0.5) 
        {
            inp = new Vector3(0, vv / 20 * spd, 0);
        }
        
        rb1.MovePosition(transform.position + inp);
        rb2.MovePosition(rb2.transform.position + inp);
    }

    float GetSpeed()
    {
        float tempSpd = baseSpeed;

        // set speed based on if the player if Focused or not
        if (Input.GetKey(KeyCode.LeftShift))
        {
            tempSpd /= 2;
        }
        if (heldObject != null && Input.GetKey(KeyCode.Z)) {
            tempSpd /= 2;
        }

        return tempSpd;
    
    }

    bool CanMove()
    {
        if((Input.GetKey(KeyCode.C)))
        {
            return false;
        }
        return true;
    }

    bool MovingObj() 
    {
        return (heldObject != null && Input.GetKey(KeyCode.Z));
    }

}
