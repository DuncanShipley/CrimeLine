using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Slider slider;
    Animator anim;

    public void Start()
    {
        anim = gameObject.GetComponent<Animator>();
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
    }
}

