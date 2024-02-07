using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCControl : MonoBehaviour
{
    public GameObject AH;
    public GameObject SH;
    public GameObject DH;
    public GameObject WH;
    public GameObject AJ;
    public GameObject SJ;
    public GameObject DJ;
    public GameObject WJ;

    Rigidbody body;
    Animator anim;
    public bool stunned = false;
    public bool canJump = false;
    /*
    for if we want diff movement per char
    public virtual int speed { get; set; }
    public virtual int jump_height { get; set; }
    public virtual int defence { get; set; }
    */
    private GameObject CurrentAttack;

    public FadeScript fadeScript;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (body.velocity.y < 2 && other.tag == "Floor")
        {
            print("hih");
            canJump = true;
        }    
    }

    private void Attack()
    {
        Instantiate(CurrentAttack, gameObject.transform, false);
        Debug.Log("plac");
    }

    private void DelAttack()
    {
        stunned = false;
        Debug.Log("pluh");
        gameObject.GetComponentInChildren<Attack>().DeleteSelf();
        
    }

    private void Unstun()
    {
        stunned = false;
    }

    private void Movement()
    {
        Vector3 vec = Vector3.one;
        bool inp = true;
        if (fadeScript.allowAction)
        {
            Debug.Log("Allow Action is true in PCControl");
            if (Input.GetKeyDown(KeyCode.W) && canJump)
            {
                print("guh");
                body.AddForce(new Vector3(0, 700, 0));
                canJump = false;

            }
            if (Input.GetKey(KeyCode.A))
            {
                vec = Vector3.Scale(vec, new Vector3(-8, 1, 1));
                transform.localScale = new Vector3(-1 * (Mathf.Abs(transform.localScale.x)), 7, 1);

            }
            else if (Input.GetKey(KeyCode.D))
            {

                vec = Vector3.Scale(vec, new Vector3(8, 1, 1));
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), 7, 1);
            }
            else
            {
                inp = false;
                body.velocity = Vector3.Scale(body.velocity, new Vector3(0, 1, 0));

            }

            if (inp)
            {

                body.velocity = new Vector3(vec.x, body.velocity.y, vec.z);
            }
        }
    }
    void Update()
    {
        Movement();
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.H) && !stunned)
        {
            CurrentAttack = AH;
            anim.SetTrigger("AH");
            stunned = true;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.H) && !stunned)
        {
            CurrentAttack = SH;
            anim.SetTrigger("SH");
            stunned = true;
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.H) && !stunned)
        {
            CurrentAttack = DH;
            anim.SetTrigger("DH");
            stunned = true;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.H) && !stunned)
        {
            CurrentAttack = WH;
            anim.SetTrigger("WH");
            stunned = true;
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.J) && !stunned)
        {
            CurrentAttack = AJ;
            anim.SetTrigger("AJ");
            stunned = true;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.J) && !stunned)
        {
            CurrentAttack = SJ;
            anim.SetTrigger("SJ");
            stunned = true;
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.J) && !stunned)
        {
            CurrentAttack = DJ;
            anim.SetTrigger("DJ");
            stunned = true;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.J) && !stunned)
        {
            CurrentAttack = WJ;
            anim.SetTrigger("WJ");
            stunned = true;
        }

    }

}
