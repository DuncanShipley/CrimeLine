using System.Collections;
using UnityEngine;


namespace Assets.Code.Fighting.EnemyManagers.EnemyAis
{
    class KenAI : EnemyAI
    {

        public override (EnemyAction, EnemyMoveAction[]) Output(EnemyAiInput input)
        {
            EnemyMoveAction[] movement = input.TouchingGround ? new EnemyMoveAction[] { EnemyMoveAction.Jump } : new EnemyMoveAction[] { };
            return (EnemyAction.KenHadouken, movement );
        }

    }
}