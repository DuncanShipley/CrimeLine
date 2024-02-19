using UnityEditor;
using UnityEngine;
using Assets.Code.Fighting.EnemyManagers;

namespace Assets.Code.Fighting.EnemyManagers
{

    public class RyuActionManager : EnemyActionScript, EnemyActionManager
    {

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

        private void Hadouken()
        {
            Instantiate(EnemyConstants.instance.Hadouken);
        }

        private void Punch()
        {
            Instantiate(EnemyConstants.instance.RyuPunch);
        }

    }
}