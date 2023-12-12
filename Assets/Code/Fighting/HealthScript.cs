using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Slider slider;
    Animator anim;
    Rigidbody body;

    public void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        body = gameObject.GetComponent<Rigidbody>();
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        if (health <= 0)
        {
            anim.SetTrigger("die");
        }
        else
        {
            anim.SetTrigger("hurt");
        }
    }

    public void TakeKnockback(Vector3 vec)
    {
        body.AddForce(vec);
    }
}

