using UnityEditor;
using UnityEngine;
using Assets.Code.Fighting.CharacterControl;

namespace Assets.Code.Fighting.CharacterControl.EnemyManagement.EnemyAis
{
    public abstract class EnemyAI
    {
        public abstract (AttackAction, MovementAction[]) Output(EnemyAiInput input);

    }

}