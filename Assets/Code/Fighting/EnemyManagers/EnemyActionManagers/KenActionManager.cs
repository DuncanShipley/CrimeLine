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
                    animator.SetTrigger("RangeSide");
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
            Instantiate(EnemyConstants.instance.Hadouken);
        }

        void Punch()
        {
            Instantiate(EnemyConstants.instance.KenPunch);
        }

    }
}