using UnityEditor;
using UnityEngine;
using Assets.Code.Fighting.EnemyManagers;

namespace Assets.Code.Fighting.EnemyManagers
{

    public class KenActionManager : EnemyActionScript, EnemyActionManager
    {

        public void TryAction(EnemyAction action)
        {
            switch (action)
            {
                case EnemyAction.KenHadouken:
                    Hadouken();
                    break;
                case EnemyAction.KenUppercut:
                    Punch();
                    break;
                case EnemyAction.KenPunch:
                    Punch();
                    break;
            }

        }

        public void TryMoveAction(EnemyMoveAction[] movement)
        {
            body.AddForce(manager.GetVector(movement));
        }



        void Hadouken()
        {
            animator.SetTrigger("hadook");
        }

        void Punch()
        {
            animator.SetTrigger("punch");
        }

    }
}