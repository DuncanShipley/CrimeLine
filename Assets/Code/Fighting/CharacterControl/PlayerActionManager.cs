using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Fighting.CharacterControl;
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
        


        public void TryAction(PlayerAction[] action)
        {
            dir = manager.DirFacing;
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
        

        public void TryMoveAction(MovementAction[] movement)
        {
            Vector3 bodyVeloicty = body.velocity;
            Assert.IsNotNull(collider);
            Assert.IsNotNull(body);
            movement = collider.TouchingGround()? movement : 
                movement.Where( action => !action.Equals(MovementAction.Jump)).ToArrayPooled();
            Vector3 velocity = manager.GetVector(movement);
            if (movement.Contains(MovementAction.Jump))
            {
                body.AddForce(Vector3.up * manager.JumpHeight);
            }

            if (movement.Contains(MovementAction.Left))
            {
                body.AddTorque(Vector3.left * 10);
            }
            
        }

        public abstract void MeleeSideAttack();

        public abstract void MeleeDownAttack();

        public abstract void MeleeUpAttack();

        public abstract void RangeSideAttack();

        public abstract void RangeDownAttack();

        public abstract void RangeUpAttack();


    }
}