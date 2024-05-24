using System.Collections;
using UnityEngine;


namespace Assets.Code.Fighting.CharacterControl.EnemyManagement.EnemyAis
{
    class RyuAI : EnemyAI
    {

        public override (PlayerAction[], MovementAction[]) Output(EnemyAiInput input)
        {
            MovementAction[] movement = { MovementAction.Jump };
            
            return (new PlayerAction[] {}, movement);
        }

    }
}