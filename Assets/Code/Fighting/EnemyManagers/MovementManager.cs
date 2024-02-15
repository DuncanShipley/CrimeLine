using System.Collections;
using UnityEngine;

namespace Assets.Code.Fighting.EnemyManagers
{
    public class MovementManager
    {
        private float WalkSpeed;
        private float JumpHeight;
        private float Gravity;

        public MovementManager(float WalkSpeed, float JumpHeight, float Gravity)
        {
            this.WalkSpeed = WalkSpeed;
            this.JumpHeight = JumpHeight;
            this.Gravity = Gravity;

        }

        public Vector3 GetVector(EnemyMoveAction[] dir)
        {
            return new Vector3(0.0f, 1.0f * JumpHeight, 0.0f);
        }



    }
}