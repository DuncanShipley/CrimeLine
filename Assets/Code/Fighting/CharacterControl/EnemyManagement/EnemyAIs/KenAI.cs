using System.Collections;
using UnityEngine;


namespace Assets.Code.Fighting.CharacterControl.EnemyManagement.EnemyAis
{
    class KenAI : EnemyAI
    {
        public override (PlayerAction[], MovementAction[]) Output(EnemyAiInput input)
        {
            MovementAction[] movement = input.TouchingGround ? new MovementAction[] { MovementAction.Jump } : new MovementAction[] { };
            return (new PlayerAction[] { PlayerAction.RangeAttack }, movement );
        }

    }
}