using UnityEditor;
using UnityEngine;
using Assets.Code.Fighting.EnemyManagers;

namespace Assets.Code.Fighting.EnemyManagers.EnemyAis
{
    public abstract class EnemyAI
    {
        public abstract (EnemyAction, EnemyMoveAction[]) Output(EnemyAiInput input);

    }

}