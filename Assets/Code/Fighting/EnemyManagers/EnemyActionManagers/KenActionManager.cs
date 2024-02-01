using UnityEditor;
using UnityEngine;
using Assets.Code.Fighting.EnemyManagers;

namespace Assets.Code.Fighting.EnemyManagers
{

    public class KenActionManager : EnemyActionScript, EnemyActionManager
    {

        private GameObject punch;
        private GameObject hadouken;

        public void TryAction(EnemyAction action)
        {
            switch (action)
            {
                case EnemyAction.KenHadouken:
                    animator.SetTrigger("hadouken");
                    break;
                case EnemyAction.KenUppercut:
                    animator.SetTrigger("punch");
                    break;
                case EnemyAction.KenPunch:

                    break;
            }

        }

        public void TryMoveAction(EnemyMoveAction[] movement)
        {

        }



        void Hadouken()
        {
            
        }

        void Punch()
        {
            animator.SetTrigger("punch");
        }

    }
}