using UnityEditor;
using UnityEngine;


namespace Assets.Code.Fighting.CharacterControl
{

    public class RyuActionManager : ActionManager
    {

        public override void TryAction(AttackAction action)
        {
            switch (action)
            {
                case AttackAction.Hadouken:
                    animator.SetTrigger("hadouken");
                    break;
                case AttackAction.RyuUppercut:
                    animator.SetTrigger("punch");
                    break;
                case AttackAction.RyuPunch:
                    break;
            }
        }

        public override void TryMoveAction(MovementAction[] movement)
        {

        }

        private void Hadouken()
        {
            Instantiate(Constants.instance.Hadouken);
        }

        private void Punch()
        {
            Instantiate(Constants.instance.RyuPunch);
        }

    }
}