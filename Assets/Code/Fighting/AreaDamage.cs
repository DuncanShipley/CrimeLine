using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDamage : MonoBehaviour
{

    private int damage { set; get; }
       
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<HealthScript>() != null)
        {
            HealthScript health = collider.GetComponent<HealthScript>();
            int newHealth = (int)(health.slider.value)-damage;
            health.SetHealth(newHealth);
        }
    }
}
