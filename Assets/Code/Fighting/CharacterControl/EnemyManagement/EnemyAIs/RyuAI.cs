using System.Collections;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


namespace Assets.Code.Fighting.CharacterControl.EnemyManagement.EnemyAis
{
    class RyuAI : EnemyAI
    {
        private float agression = 0.0f;

        public override (PlayerAction[], MovementAction[]) Output(EnemyAiInput input)
        {

            agression += Time.deltaTime * 0.3f;
                
            MovementAction[] movement = {};
            PlayerAction[] attacks = { PlayerAction.MeleeAttack };
            
            
            
            if (input.DistanceToPC > 7f)
            {
                attacks = new PlayerAction[] { PlayerAction.RangeAttack };

                return (attacks, movement);
            }
          
            if (input.PCPosition.x - input.MyPosition.x > 0)
            {
                movement = new MovementAction[] {  MovementAction.Right };
            }
            else
            {

                movement = new MovementAction[] {  MovementAction.Left };
            }
            return (new PlayerAction[] { PlayerAction.MeleeAttack }, movement);
        }

    }
}