using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC2Control : MonoBehaviour
{
    Rigidbody gonk;
    bool canJump = false;
    // Start is called before the first frame update
    void Start()
    {
        gonk = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        print("hih");
        canJump = true;
    }



    // Update is called once per frame
    void Update()
    {


        Vector3 vec = Vector3.one;
        bool inp = true;
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            print("guh");
            gonk.AddForce(new Vector3(0,700,0));
            canJump = false;

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vec = Vector3.Scale(vec, new Vector3(-8, 1, 1));
            
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {

            vec = Vector3.Scale(vec, new Vector3(8, 1, 1));
        }
        else
        {
            inp = false;
            gonk.velocity = Vector3.Scale(gonk.velocity , new Vector3(0, 1, 0));
           
        }

        if (inp)
        {
      
            gonk.velocity = new Vector3(vec.x, gonk.velocity.y, vec.z);
        }
        
    }
}
