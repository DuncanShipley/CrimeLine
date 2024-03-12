using System.Collections;
using UnityEngine;

namespace Assets.Code.Fighting.CharacterControl
{
   
    public enum AttackAction
    {
        DownLeft,
        KenPunch,
        KenUppercut,
        RyuPunch,
        RyuUppercut,
        Hadouken,
        

    }

    public enum PlayerAction
    {
        Block,
        Jump, 
        MeleeAttack,
        RangeAttack,
        MoveLeft,
        MoveRight,
        MoveUp,
        MoveDown,
    }

    public enum MovementAction
    {
        Right,
        Left,
        Jump,
    }

  
}