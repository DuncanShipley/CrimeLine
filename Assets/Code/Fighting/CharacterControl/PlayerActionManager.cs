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
        public Animator anim;
        public Rigidbody body;
        protected int test;
        public bool blocking;
        protected MovementManager manager = new MovementManager(1,1,1);
        protected bool stunned = false;
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
                            stunned = true;
                            break;
                        case PlayerAction.MeleeAttack:
                            switch(dir)
                            {
                                case 0:
                                    anim.SetTrigger("MeleeSide");
                                    stunned = true;
                                    break;
                                case 1:
                                    anim.SetTrigger("MeleeUp");
                                    stunned = true;
                                    break;
                                case 2:
                                    anim.SetTrigger("MeleeDown");
                                    stunned = true;
                                    break;
                            }
                            break;
                        case PlayerAction.RangeAttack:
                            switch (dir)
                            {
                                case 0:
                                    anim.SetTrigger("RangeSide");
                                    stunned = true;
                                    break;
                                case 1:
                                    anim.SetTrigger("RangeUp");
                                    stunned = true;
                                    break;
                                case 2:
                                    anim.SetTrigger("RangeDown");
                                    stunned = true;
                                    break;
                            }
                            break;
                    }
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

        public abstract void Block();

        public abstract void DeBlock();


    }
}