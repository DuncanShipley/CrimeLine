using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Fighting.CharacterControl;
using Unity.VisualScripting;
using UnityEngine;


namespace Assets.Code.Fighting.CharacterControl
{
    public abstract class PlayerActionManager : MonoBehaviour
    {
        protected float dir;
        public Animator anim;
        public Rigidbody body;
        public bool blocking;
        protected MovementManager movementManager;
        protected bool stunned = false;
        protected Collider collider;


        public PlayerActionManager()
        {
            collider = body.GetComponent<Collider>();
        }
        
        public void TryAction(PlayerAction[] action)
        {
            dir = movementManager.DirFacing;
            foreach (var Item in action)
            {
                if (!stunned)
                {
                    switch(Item)
                    {
                        case PlayerAction.Block:
                            anim.SetTrigger("Block");
                            break;
                        case PlayerAction.MeleeAttack:
                            switch(dir)
                            {
                                case 0:
                                    anim.SetTrigger("MeleeSide");
                                    break;
                                case 1:
                                    anim.SetTrigger("MeleeUp");
                                    break;
                                case 2:
                                    anim.SetTrigger("MeleeDown");
                                    break;
                            }
                            break;
                        case PlayerAction.RangeAttack:
                            switch (dir)
                            {
                                case 0:
                                    anim.SetTrigger("RangeSide");
                                    break;
                                case 1:
                                    anim.SetTrigger("RangeUp");
                                    break;
                                case 2:
                                    anim.SetTrigger("RangeDown");
                                    break;
                            }
                            break;
                    }
                }
            }
        }
        
        protected abstract bool TouchingGround();

        public void TryMoveAction(MovementAction[] movement)
        {
            movement = TouchingGround()? movement : 
                movement.Where( action => !action.Equals(MovementAction.Jump)).ToArrayPooled();
            Vector3 velocity = movementManager.GetVector(movement);
            if (movement.Contains(MovementAction.Jump))
            {
                body.AddForce(Vector3.up * movementManager.JumpHeight);
            }

            body.velocity = velocity;


        }

        public abstract void MeleeSideAttack();

        public abstract void MeleeDownAttack();

        public abstract void MeleeUpAttack();

        public abstract void RangeSideAttack();

        public abstract void RangeDownAttack();

        public abstract void RangeUpAttack();


    }
}