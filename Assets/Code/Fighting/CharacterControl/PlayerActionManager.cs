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
        

        public void TryMoveAction(MovementAction[] movement)
        {
            body.velocity = manager.GetVector(movement, collider, body);
        }

        public abstract void MeleeSideAttack();

        public abstract void MeleeDownAttack();

        public abstract void MeleeUpAttack();

        public abstract void RangeSideAttack();

        public abstract void RangeDownAttack();

        public abstract void RangeUpAttack();


    }
}