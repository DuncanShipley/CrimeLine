using System.Collections;
using System.Collections.Generic;
using Assets.Code.Fighting.CharacterControl;
using UnityEngine;

public class PlayerActionManager : MonoBehaviour
{
    protected Animator animator;
    protected Rigidbody body;
    protected MovementManager manager;
    protected bool stunned = false;
    public void TryAction(PlayerAction[] action)
    {

        foreach (var Item in action)
        {
            switch(Item)
            {
                case PlayerAction.Block:

                    break;
                case PlayerAction.Jump:

                    break;
                case PlayerAction.MeleeAttack:
                    //get move direction
                    //Start Attack in right direction
                    break;
                case PlayerAction.RangeAttack:
                    //get move direction
                    //Start Attack in right direction
                    break;
            }
        }
    }

    public void TryMoveAction(MovementAction[] movement)
    {
        body.AddForce(manager.GetVector(movement));
    }
}
