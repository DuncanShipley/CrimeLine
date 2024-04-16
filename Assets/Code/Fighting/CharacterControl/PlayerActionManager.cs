using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Fighting.CharacterControl;
using UnityEngine;


namespace Assets.Code.Fighting.CharacterControl
{
    public abstract class PlayerActionManager : MonoBehaviour
    {
        protected float dir;
        protected Animator anim;
        public Rigidbody body;//ben help please
        protected int test;
        public bool blocking;
        protected MovementManager manager = new MovementManager(1,1,1);
        protected bool stunned = false;
        public void TryAction(PlayerAction[] action)
        {
            dir = manager.DirFacing;
            foreach (var Item in action)
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
                                MeleeSideAttack();//prob dont need to call the functions
                                break;
                            case 1:
                                anim.SetTrigger("MeleeUp");
                                MeleeDownAttack();
                                break;
                            case 2:
                                anim.SetTrigger("MeleeDown");
                                MeleeUpAttack();
                                break;
                        }
                        break;
                    case PlayerAction.RangeAttack:
                        switch (dir)
                        {
                            case 0:
                                anim.SetTrigger("RangeSide");
                                RangeSideAttack();
                                break;
                            case 1:
                                anim.SetTrigger("RangeUp");
                                RangeDownAttack();
                                break;
                            case 2:
                                anim.SetTrigger("RangeDown");
                                RangeUpAttack();
                                break;
                        }
                        break;
                }
            }
        }

        public void TryMoveAction(MovementAction[] movement)
        {
            body.velocity = manager.GetVector(movement);
            
        }

        public abstract void MeleeSideAttack();

        public abstract void MeleeDownAttack();

        public abstract void MeleeUpAttack();

        public abstract void RangeSideAttack();

        public abstract void RangeDownAttack();

        public abstract void RangeUpAttack();


    }
}