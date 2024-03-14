using System.Collections;
using UnityEngine;


namespace Assets.Code.Fighting.CharacterControl
{
    public abstract class ActionManager : MonoBehaviour { 

        protected Animator animator;
        protected Rigidbody body;
        protected MovementManager manager;
        protected bool stunned = false;
    
        public abstract void TryAction(AttackAction action);

        public abstract void TryMoveAction(MovementAction[] movement);
    }
}

