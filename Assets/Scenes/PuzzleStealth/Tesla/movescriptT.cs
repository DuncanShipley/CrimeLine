using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class movescriptT : MonoBehaviour
{
    GameObject copy;
    public GameObject projectile;
    Vector3 lastInput;
    float h = 0f;
    float v = 0f;
    float throwPause = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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


        //rotation
        var rot = 0f;
        var quad = 0f;
        if (h != 0)
            rot = (Mathf.Abs(180 * ((float)(Math.Atan(v / h))) / (float)Math.PI))%90;
        else
            h = 0;
        
        if (h > 0 && v > 0)
            //rot = -rot;
        if (h > 0 && v < 0)
            //rot;
        Debug.Log(h + " " + v);
        //Debug.Log(rot);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, rot);
        //transform.Rotate(0, 0, rot);
        //transform.Rotate(h, v, 0);

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
        if (Input.GetKeyDown(KeyCode.V) && projectileT.availible > 0 && throwPause>=1)
        {
            throwPause = 0;
            //projectileT.availible--;
            copy = Instantiate(projectile, gameObject.transform.position, new Quaternion());
            var projectileRB = copy.GetComponent<Rigidbody2D>();
            projectileRB.AddRelativeForce(lastInput);
        }
    }
}