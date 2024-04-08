using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class movescriptTesla : MonoBehaviour
{
    public GameObject projectile;
    float h = 0f;
    float v = 0f;

    // Start is called before the first frame update
    void Start()
    {
        projectile = GameObject.Find("projectile");
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
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
            Vector3 inp = new Vector3(h / spd * Time.timeScale, v / spd * Time.timeScale, 0);
            rb.MovePosition(transform.position + inp);

            GetComponent<Animator>().SetInteger("playerDir", makeAnimDir());


        }

    }

    int makeAnimDir()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (Math.Abs(h) > Math.Abs(v))
        {
            if (h > 0)
            {
                return 2;
            }
            else if (h < 0)
            {
                return 4;
            }
        }
        else if (Math.Abs(h) < Math.Abs(v))
        {
            if (v > 0)
            {
                return 1;
            }
            else if (v < 0)
            {
                return 3;
            }
        }
        return 0;
    }
}
