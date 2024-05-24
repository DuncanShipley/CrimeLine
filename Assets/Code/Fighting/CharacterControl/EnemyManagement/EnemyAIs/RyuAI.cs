using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.PlayerLoop;


namespace Assets.Code.Fighting.CharacterControl.EnemyManagement.EnemyAis
{
    class RyuAI : EnemyAI
    {
        private float aggression = 0.0f;
        private const float TRY_MELEE_DISTANCE = 7.0f;
        private float shuffleDir = 0;


        private MovementAction[] Shuffle(Vector3 velocity)
        {
            float rand = Random.Range(-1.0f, 1.0f);
            bool jump = Mathf.Abs(rand) > 0.97;
            bool goLeft = velocity.x > 0 ? rand < -0.99f : rand < 0.99f;
            List<MovementAction> actions = new List<MovementAction>();
            
            if (goLeft)
            {
                actions.Add(MovementAction.Left);
            }else
            {
                actions.Add(MovementAction.Right);
            }
            if (jump)
            {
                actions.Add(MovementAction.Jump);
            }
            
            return actions.ToArray();

        }

        private MovementAction[] Charge(Vector3 myPos, Vector3 PCpos)
        {
            return PCpos.x - myPos.x > 0
                ? new MovementAction[] { MovementAction.Right }
                : new MovementAction[] { MovementAction.Left };
  
        }

        public override (PlayerAction[], MovementAction[]) Output(EnemyAiInput input)
        {

            
            aggression += Time.deltaTime;
            Debug.unityLogger.Log(aggression);
            
            bool proactive = aggression > 7.0f;
            bool reactive = input.DistanceToPC <  3.0f + (aggression / 2);
            
            MovementAction[] movement = {};
            PlayerAction[] attacks = { PlayerAction.MeleeAttack };


            if (proactive)
            {
                if (input.DistanceToPC > TRY_MELEE_DISTANCE)
                {
                    attacks = new PlayerAction[] { PlayerAction.RangeAttack };
                    aggression -= 5.0f;
                    return (attacks, Charge(input.MyPosition, input.PCPosition));
                }

                if (input.DistanceToPC < 1.0f)
                {
                    aggression -= 9.0f;
                    return (new PlayerAction[] { PlayerAction.MeleeAttack },
                        Charge(input.MyPosition, input.PCPosition));
                   
                }

                return (new PlayerAction[] { }, Charge(input.MyPosition, input.PCPosition));


            }

            PlayerAction attack = input.DistanceToPC < TRY_MELEE_DISTANCE
                ? PlayerAction.MeleeAttack
                : PlayerAction.RangeAttack;
            
         
            return (
                Random.Range(0.0f, 1.0f) > 0.99 ? new PlayerAction[] {attack} : new PlayerAction[] {}, 
                Shuffle(input.MyVelocity)
                );
            

            
        }

    }
}