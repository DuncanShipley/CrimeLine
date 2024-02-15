using System.Collections;
using UnityEngine;
using Assets.Code.Fighting.EnemyManagers;

namespace Assets.Code.Fighting.EnemyManagers
{

    public interface EnemyActionManager
    {

        
        public  void TryAction(EnemyAction action);

        public void TryMoveAction(EnemyMoveAction[] movement);
    }

    public abstract class EnemyActionScript : MonoBehaviour
    {

        protected Animator animator;
        protected Rigidbody body;
        protected MovementManager manager;
        protected bool stunned = false;
        protected void Start()
        {
            body = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
        }
    }
    
}

