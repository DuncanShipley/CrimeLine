using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCControl : MonoBehaviour
{
    public GameObject Punch;
    Rigidbody body;
    bool canJump = false;
    Animator anim;
    bool stunned = false;

    private GameObject CurrentAttack;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        print("hih");
        canJump = true;
    }




    private void Attack()
    {
        Instantiate(CurrentAttack, gameObject.transform, false);
    }

    private void DelAttack()
    {
        gameObject.GetComponentInChildren<Attack>().DeleteSelf();
    }

    private void UnStun()
    {
        stunned = false;
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 vec = Vector3.one;
        bool inp = true;
        
        if (Input.GetKeyDown(KeyCode.W) && canJump)
        {
            print("guh");
            body.AddForce(new Vector3(0,700,0));
            canJump = false;

        }
        if (Input.GetKey(KeyCode.A))
        {
            vec = Vector3.Scale(vec, new Vector3(-8, 1, 1));
            
        }
        else if (Input.GetKey(KeyCode.D))
        {

            vec = Vector3.Scale(vec, new Vector3(8, 1, 1));
        }
        else
        {
            inp = false;
            body    .velocity = Vector3.Scale(body.velocity , new Vector3(0, 1, 0));
           
        }

        if (inp)
        {
      
            body.velocity = new Vector3(vec.x, body.velocity.y, vec.z);
        }

        if (Input.GetKey(KeyCode.H) && !stunned)
        {
            CurrentAttack = Punch;
            anim.SetTrigger("punch");
            stunned = true;
            Invoke("UnStun" , 0.5f);
        }

        
    }

}
