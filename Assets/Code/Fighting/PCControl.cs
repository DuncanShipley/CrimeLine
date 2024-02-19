using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCControl : MonoBehaviour
{
    public GameObject SideH;
    public GameObject SH;
    public GameObject WH;
    public GameObject SideJ;
    public GameObject SJ;
    public GameObject WJ;

    Rigidbody body;
    Animator anim;
    public bool stunned = false;
    public bool canJump = false;
    public bool blocking = false;

    [SerializeField] private AudioClip groundSpikeSFX;
    [SerializeField] private AudioClip uppercutSFX;
    [SerializeField] private AudioClip whipSFX;
    [SerializeField] private AudioClip knifeSFX;
    [SerializeField] private AudioClip shieldPushSFX;
    [SerializeField] private AudioClip ballSFX;
    [SerializeField] private AudioClip jumpSFX;
    /*
    for if we want diff movement per char
    public virtual int speed { get; set; }
    public virtual int jump_height { get; set; }
    public virtual int defence { get; set; }
    */
    private GameObject CurrentAttack;

    public FadeScript fadeScript;

    public HealthScript healthScript;

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
        if (fadeScript.allowAction)
        {
            Movement();
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.H) && !stunned)
            {
                SFXManager.instance.PlaySFXClip(groundSpikeSFX, transform, 1f);
                CurrentAttack = SideH;
                anim.SetTrigger("SideH");
                stunned = true;
            }
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.H) && !stunned)
            {
                SFXManager.instance.PlaySFXClip(uppercutSFX, transform, 1f);
                CurrentAttack = SH;
                anim.SetTrigger("SH");
                stunned = true;
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.H) && !stunned)
            {
                //ground spike
                CurrentAttack = SideH;
                anim.SetTrigger("SideH");
                stunned = true;
            }
            if (Input.GetKey(KeyCode.H) && !stunned)
            {
                //whip
                CurrentAttack = WH;
                anim.SetTrigger("WH");
                stunned = true;
            }

            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.J) && !stunned)
            {
                //knife
                CurrentAttack = SideJ;
                anim.SetTrigger("SideJ");
                stunned = true;
            }
            if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.J) && !stunned)
            {
                //shieldpush
                CurrentAttack = SJ;
                anim.SetTrigger("SJ");
                stunned = true;
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.J) && !stunned)
            {
                //knife
                CurrentAttack = SideJ;
                anim.SetTrigger("SideJ");
                stunned = true;
            }
            if (Input.GetKey(KeyCode.J) && !stunned)
            {
                //ball
                CurrentAttack = WJ;
                anim.SetTrigger("WJ");
                stunned = true;
            }
        }
    }


}
