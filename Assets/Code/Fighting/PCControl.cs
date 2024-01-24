using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCControl : MonoBehaviour
{
    public GameObject Uppercut;
    public GameObject Hadukenm;
    Rigidbody body;
    bool canJump = false;
    Animator anim;
    bool stunned = false;

    private GameObject CurrentAttack;

    public FadeScript fadeScript;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        print("hih");
        if (body.velocity.y < 2 && other.tag == "Floor")
        {
            canJump = true;
        }    
    }


    


    private void Attack()
    {
        Instantiate(CurrentAttack, gameObject.transform, false);
    }

    private void DelAttack()
    {
        stunned = false;
        gameObject.GetComponentInChildren<Attack>().DeleteSelf();
        
    }

    private void Unstun()
    {
        stunned = false;
    }

    

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = Vector3.one;
        bool inp = true;
        if (fadeScript.allowaction)
        {
            if (Input.GetKeyDown(KeyCode.W) && canJump)
            {
                print("guh");
                body.AddForce(new Vector3(0, 700, 0));
                canJump = false;

        }
        if (Input.GetKey(KeyCode.A))
        {
            vec = Vector3.Scale(vec, new Vector3(-8, 1, 1));
            transform.localScale = new Vector3(-1*(Mathf.Abs(transform.localScale.x)), 7, 1);

        }
        else if (Input.GetKey(KeyCode.D))
        {

            vec = Vector3.Scale(vec, new Vector3(8, 1, 1));
            transform.localScale = new Vector3 (Mathf.Abs(transform.localScale.x),7 ,1 );
        }
        else
        {
            inp = false;
            body.velocity = Vector3.Scale(body.velocity , new Vector3(0, 1, 0));
           
        }

                vec = Vector3.Scale(vec, new Vector3(8, 1, 1));
            }
            else
            {
                inp = false;
                body.velocity = Vector3.Scale(body.velocity, new Vector3(0, 1, 0));

        if (Input.GetKey(KeyCode.H) && !stunned)
        {
            CurrentAttack = Uppercut;
            anim.SetTrigger("uppercoot");
            stunned = true;
            
        }

            if (inp)
            {

                body.velocity = new Vector3(vec.x, body.velocity.y, vec.z);
            }

            if (Input.GetKey(KeyCode.H) && !stunned)
            {
                CurrentAttack = Uppercut;
                anim.SetTrigger("punch");
                stunned = true;

            }

            if (Input.GetKey(KeyCode.J) && !stunned)
            {
                CurrentAttack = Hadukenm;
                anim.SetTrigger("Hadook");
                stunned = true;
            }
        }
    }

}
