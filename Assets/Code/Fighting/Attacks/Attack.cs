﻿using System.Collections;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;



public abstract class Attack : MonoBehaviour
{
    protected float dir;
    float num;
    public virtual int damage { get; set;}

    public virtual Vector3 knockback { get; set; }

    public void Start()
    {
        this.num = gameObject.transform.parent.localScale.x;
        this.dir = num / Mathf.Abs(num);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<HealthScript>() != null)
        {
            HealthScript health = collider.GetComponent<HealthScript>();
            int newHealth = (int)(health.slider.value) - damage;
            health.SetHealth(newHealth);
            health.TakeKnockback(knockback);
            
            
        }
    }
    public void DeleteSelf()
    {
        Destroy(gameObject);
    }
}

    
