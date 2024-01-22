using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class movescript : MonoBehaviour
{
    public GameObject projectile;
    float h = 0f;
    float v = 0f;
<<<<<<< HEAD
=======
    float throwPause = 0;
    string dir;
>>>>>>> main
    // Start is called before the first frame update
    void Start()
    {
        projectile = GameObject.Find("projectile");
    }

    // Update is called once per frame
    void Update()
    {
        if(true)
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

<<<<<<< HEAD
=======
            gameObject.GetComponent<Animation>().Play("walk" + makeAnimDir());

            //projectiles
            if ((Mathf.Abs(h) > 0) || (Mathf.Abs(v) > 0))
            {
                if (Mathf.Abs(h) > 0)
                    lastInput.x = (h / Mathf.Abs(h)) * 100;
                else if (Mathf.Abs(v) - Mathf.Abs(h) > .1)
                    lastInput.x = 0;

                if (Mathf.Abs(v) > 0)
                    lastInput.y = (v / Mathf.Abs(v)) * 100;
                else if (Mathf.Abs(h) - Mathf.Abs(v) > .1)
                    lastInput.y = 0;
            }
            throwPause += Time.deltaTime;

            //creates a projectile moving in the same direction as last player movement
            if (Input.GetKeyDown(KeyCode.E) && projectileT.availible > 0 && throwPause >= 1)
            {
                throwPause = 0;
                projectileT.availible--;
                copy = Instantiate(projectile, gameObject.transform.position, new Quaternion());
                var pRB = copy.GetComponent<Rigidbody2D>();
                pRB.AddRelativeForce(lastInput);
            }
>>>>>>> main
        }

    }

    string makeAnimDir()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (Math.Abs(h) > Math.Abs(v))
        {
            if (h > 0)
            {
                return "left";
            }
            else if (h < 0)
            {
                return "right";
            }
        }
        else if (Math.Abs(h) < Math.Abs(v))
        {
            if (v > 0)
            {
                return "up";
            }
            else if (v < 0)
            {
                return "down";
            }
        }
        return null;
    }
}
