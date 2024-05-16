using System;
using System.Collections;
using System.ComponentModel;
using Code.Fighting.Utils;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Assets.Code.Fighting.CharacterControl
{
    public class MovementManager
    {
        public float WalkSpeed;
        public float JumpHeight;
        public float Gravity;
        public float DirFacing;
        public bool Crouching;
        

        public MovementManager(float WalkSpeed, float JumpHeight, float Gravity)
        {
            this.WalkSpeed = WalkSpeed;
            this.Gravity = -9.81f * Gravity;
            this.JumpHeight = (float) Math.Sqrt((4 * JumpHeight * Math.Pow(this.Gravity, 2)) / -this.Gravity);
        }

        
        public Vector3 GetVector(MovementAction[] move, Collider collider, Rigidbody body)
        {
            Vector3 vec = new Vector3();
            foreach (var item in move){//we have to do more stuff
                switch (item)
                {
                    case MovementAction.Jump:
                        if (collider.TouchingGround())
                        {
                            vec.y = JumpHeight;
                        }
                        break;
                    case MovementAction.Right:
                        vec.x = WalkSpeed;
                        DirFacing = 0;
                        break;
                    case MovementAction.Left:
                        vec.x = -WalkSpeed;
                        DirFacing = 0;
                        break;
                    case MovementAction.Up:
                        //how do we want to do crouching and like looking up or smth
                        DirFacing = 1;
                        break;
                    case MovementAction.Down:
                        //crouch
                        DirFacing = 2;
                        break;
                }
            }
            if (!collider.TouchingGround())
            {
                vec.y = body.velocity.y;
            }
            return vec;
        }



    }
}