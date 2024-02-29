namespace Assets.Code.Fighting.CharacterControl
{

    public class KenActionManager :  ActionManager
    {

        public override void TryAction(AttackAction action)
        {
            switch (action)
            {
                case AttackAction.Hadouken:
                    animator.SetTrigger("Hadook");
                    break;
                case AttackAction.KenUppercut:
                    animator.SetTrigger("uppercoot");
                    break;
                case AttackAction.KenPunch:
                    Punch();
                    break;
            }

        }

        public override void TryMoveAction(MovementAction[] movement)
        {
            body.AddForce(manager.GetVector(movement));
        }



        void Hadouken()
        {
            Instantiate(Constants.instance.Hadouken);
        }

        void Punch()
        {
            Instantiate(Constants.instance.KenPunch);
        }

    }
}