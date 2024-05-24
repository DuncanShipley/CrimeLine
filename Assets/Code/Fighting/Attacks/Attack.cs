using System.Collections;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using Assets.Code.Fighting.CharacterControl;


public abstract class Attack : MonoBehaviour
{
    protected float dir;
    float num;
    public virtual int damage { get; set;}

    public virtual Vector3 knockback { get; set; }

    public virtual bool Staged { get; set;}

    public void Start()
    {
        if (Staged){
            this.num = gameObject.transform.parent.parent.GetComponent<PlayerActionManager>().dirFacing();
        } else
        {
            this.num = gameObject.transform.parent.GetComponent<PlayerActionManager>().dirFacing();
        }
        this.dir = this.num == 1? -1 : 1;
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

    
