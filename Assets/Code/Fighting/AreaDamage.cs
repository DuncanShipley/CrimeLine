using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDamage : MonoBehaviour
{
    private int damage;

    private void SetDamage(int damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<EnemyHealthScript>() != null)
        {
            EnemyHealthScript health = collider.GetComponent<EnemyHealthScript>();
            int newHealth = (int)(health.slider.value)-damage;
            health.SetHealth(newHealth);
        }
    }
}
