﻿using System.Collections;
using UnityEngine;


namespace Assets.Code.Fighting.EnemyManagers.EnemyAis
{
    class RyuAI : EnemyAI
    {

        public override (EnemyAction, EnemyMoveAction[]) Output(EnemyAiInput input)
        {
            EnemyMoveAction[] movement = { EnemyMoveAction.Right };
            return (EnemyAction.KenHadouken, movement);
        }

    }
}