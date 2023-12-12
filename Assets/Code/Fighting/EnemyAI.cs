using System.Collections;
using UnityEngine;

namespace Assets.Code.Fighting {


    public class EnemyManager : MonoBehaviour
    {


    }

    public abstract class EnemyAIAction { 
       public abstract string Output(EnemyAiInput input);
       

    }

    public struct EnemyAiInput
    {
        float distanceToPC;
        bool  touchingGround;
        bool  canAttack;
        float PCPosition;
    }
}