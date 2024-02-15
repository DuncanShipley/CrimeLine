using UnityEditor;
using UnityEngine;
using Assets.Code.Fighting.EnemyManagers;
using Unity.VisualScripting.Antlr3.Runtime;

namespace Assets.Code.Fighting.EnemyManagers
{

    public class KenActionManager : EnemyActionScript, EnemyActionManager
    {
        
        public void TryAction(EnemyAction action)
        {
            Instantiate(EnemyConstants.AttackPrefabs.TryGetValue(action));
        }

        public void TryMoveAction(EnemyMoveAction[] movement)
        {
            body.AddForce(manager.GetVector(movement));
        }


       

    }
}