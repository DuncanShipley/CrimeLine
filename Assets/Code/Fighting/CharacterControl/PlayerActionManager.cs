using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Fighting.CharacterControl;
using Cinemachine;
using EasyRoads3Dv3;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;


namespace Assets.Code.Fighting.CharacterControl
{
    
    
    public abstract class PlayerActionManager : MonoBehaviour
    {
        protected float dir;
        public Animator anim;
        public Rigidbody body;
        public bool blocking;
        protected abstract MovementManager manager { get; }
        protected bool stunned = false;
        public new Collider collider;
        
        
        
        public GameObject MeleeSide;
        public GameObject MeleeUp;
        public GameObject MeleeDown;
        public GameObject RangeSide;
        public GameObject RangeUp;
        public GameObject RangeDown;
        [SerializeField] private AudioClip MSideSFX;
        [SerializeField] private AudioClip MDownSFX;
        [SerializeField] private AudioClip MUpSFX;
        [SerializeField] private AudioClip RSideSFX;
        [SerializeField] private AudioClip RDownSFX;
        [SerializeField] private AudioClip RUpSFX;

        private void Start()
        {
            body.useGravity = false;
        }

        private void FixedUpdate()
        {
            body.velocity += new Vector3(0.0f, manager.Gravity * Time.deltaTime, 0.0f);
        }


        public void TryAction(PlayerAction[] action)
        {
            dir = manager.DirFacing;
            foreach (var Item in action)
            {
                if (stunned)
                {
                    continue;
                }
                switch(Item)
                {
                    case PlayerAction.Block:
                        anim.SetTrigger("Block");
                        break;
                    case PlayerAction.MeleeAttack:
                        switch(dir)
                        {
                            case <2:
                                anim.SetTrigger("MeleeSide");
                                stunned = true;
                                break;
                            case 2:
                                anim.SetTrigger("MeleeUp");
                                stunned = true;
                                break;
                            case 3:
                                anim.SetTrigger("MeleeDown");
                                stunned = true;
                                break;
                        }
                        break;
                    case PlayerAction.RangeAttack:
                        switch (dir)
                        {
                            case <2:
                                anim.SetTrigger("RangeSide");
                                stunned = true;
                                break;
                            case 2:
                                anim.SetTrigger("RangeUp");
                                stunned = true;
                                break;
                            case 3:
                                anim.SetTrigger("RangeDown");
                                stunned = true;
                                break;
                        }
                        break;
                }
                
            }
        }
        

        public void TryMoveAction(MovementAction[] movement)
        {
            body.velocity = manager.GetVector(movement, collider, body);
        }

        public virtual void MeleeSideAttack()
        {
            SFXManager.instance.PlaySFXClip(MSideSFX, transform, 1f);
            Instantiate(this.MeleeSide, gameObject.transform, false);
        }

        public virtual void MeleeDownAttack()
        {
            SFXManager.instance.PlaySFXClip(MDownSFX, transform, 1f);
            Instantiate(this.MeleeDown, gameObject.transform, false);
        }

        public virtual void MeleeUpAttack()
        {
            SFXManager.instance.PlaySFXClip(MUpSFX, transform, 1f);
            Instantiate(this.MeleeUp, gameObject.transform, false);
        }

        public virtual void RangeSideAttack()
        {
            SFXManager.instance.PlaySFXClip(RSideSFX, transform, 0.3f);
            Instantiate(this.RangeSide, gameObject.transform, false);
        }

        public virtual void RangeUpAttack()
        {
            SFXManager.instance.PlaySFXClip(RUpSFX, transform, 0.3f);
            Instantiate(this.RangeUp, gameObject.transform, false);
        }

        public virtual void RangeDownAttack()
        {
            SFXManager.instance.PlaySFXClip(RDownSFX, transform, 3f);
            Instantiate(this.RangeDown, gameObject.transform, false);
        }
        private void DelAttack()
        {
            if (gameObject.GetComponentInChildren<Attack>() != null)
                gameObject.GetComponentInChildren<Attack>().DeleteSelf();
        }
        private void Unstunn()
        {
            stunned = false;
        }
        
        protected virtual void Block()
        {
            blocking = true;
            // might what to make movemanger check if blocking before adding kb
        }

        public virtual void setStun(bool isStunned)
        {
            stunned = isStunned;
        }

        public int dirFacing(){
            return (int)manager.DirFacing;
        }

        public virtual void DeBlock()
        {
            blocking = false;
        }

    }
}