using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDamage : MonoBehaviour
{
    private float damage;

    private void SetDamage(float damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<EnemyHealthScript>() != null)
        {
            EnemyHealthScript health = collider.GetComponent<EnemyHealthScript>();
            int newHealth = health.slider.value-damage;
            health.SetHealth(newHealth);
        }
    }
}
