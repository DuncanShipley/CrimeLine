using UnityEditor;
using UnityEngine;
using Assets.Code.Fighting.EnemyManagers;

namespace Assets.Code.Fighting.EnemyManagers
{

    public class RyuActionManager : EnemyActionScript, EnemyActionManager
    {

        private GameObject punch;
        private GameObject hadouken;

        public void TryAction(EnemyAction action)
        {
            switch (action)
            {
                case EnemyAction.RyuHadouken:
                    animator.SetTrigger("hadouken");
                    break;
                case EnemyAction.RyuUppercut:
                    animator.SetTrigger("punch");
                    break;
                case EnemyAction.RyuPunch:
                    break;
            }
        }

        public void TryMoveAction(EnemyMoveAction[] movement)
        {

        }

        void Hadouken()
        {
            animator.SetTrigger("hadook");

        }

        void Punch()
        {
            animator.SetTrigger("uppdercoot");
        }

    }
}