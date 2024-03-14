using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Fighting.CharacterControl;
using UnityEngine;

public abstract class PlayerActionManager : MonoBehaviour
{
    protected Animator anim;
    protected Rigidbody body;
    protected MovementManager manager;
    protected bool stunned = false;
    protected float dir;
    public void TryAction(PlayerAction[] action)
    {
        dir = manager.DirFacing;
        foreach (var Item in action)
        {
            switch(Item)
            {
                case PlayerAction.Block:
                    //idk how ima do block yet
                    break;
                case PlayerAction.MeleeAttack:
                    switch(dir)
                    {
                        case 0:
                            anim.SetTrigger("MeleeSide");
                            MeleeSide();
                            break;
                        case 1:
                            anim.SetTrigger("MeleeUp");
                            MeleeDown();
                            break;
                        case 2:
                            anim.SetTrigger("MeleeDown");
                            MeleeUp();
                            break;
                    }
                    break;
                case PlayerAction.RangeAttack:
                    switch (dir)
                    {
                        case 0:
                            anim.SetTrigger("RangeSide");
                            RangeSide();
                            break;
                        case 1:
                            anim.SetTrigger("RangeUp");
                            RangeDown();
                            break;
                        case 2:
                            anim.SetTrigger("RangeDown");
                            RangeUp();
                            break;
                    }
                    break;
            }
        }
    }

    public void TryMoveAction(MovementAction[] movement)
    {
        body.AddForce(manager.GetVector(movement));
    }

    public abstract void MeleeSide();

    public abstract void MeleeDown();

    public abstract void MeleeUp();

    public abstract void RangeSide();

    public abstract void RangeDown();

    public abstract void RangeUp();


}
