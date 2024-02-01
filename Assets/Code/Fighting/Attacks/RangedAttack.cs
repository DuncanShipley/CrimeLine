using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedAttack : Attack
{
    private Rigidbody rb;
    private Animator anim;
    public virtual int speed { get; set; }
    public virtual int height { get; set; }
    public virtual bool limited { get; set; }
    public virtual float time { get; set; }


    public void Start()
    {
        if (limited)
        {
            Invoke("DeleteSelf", time);
        }
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        rb.velocity = new Vector3(speed*dir, height, 0);
        gameObject.transform.parent = null;
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<HealthScript>() != null)
        {
            anim.SetTrigger("hit");
            HealthScript health = collider.GetComponent<HealthScript>();
            int newHealth = (int)(health.slider.value) - damage;
            health.SetHealth(newHealth);
            health.TakeKnockback(knockback);
            DeleteSelf();
        }
    }
}
