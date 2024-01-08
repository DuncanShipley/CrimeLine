using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedAttack : Attack
{
    private Rigidbody rb;
    private Animator anim;
    protected float dir;
    float num;
    public virtual int speed { get; set; }
    public void Start()
    {
        float num = gameObject.transform.parent.localScale.x;
        float dir = num / Mathf.Abs(num);
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        rb.velocity = new Vector3(speed*dir, 0, 0);
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
