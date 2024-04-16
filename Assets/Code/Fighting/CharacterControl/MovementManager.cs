using System.Collections;
using UnityEngine;

namespace Assets.Code.Fighting.CharacterControl
{
    public class MovementManager
    {
        private float WalkSpeed;
        private float JumpHeight;
        private float Gravity;
        public float DirFacing;
        private bool Crouching;

        public MovementManager(float WalkSpeed, float JumpHeight, float Gravity)
        {
            this.WalkSpeed = WalkSpeed;
            this.JumpHeight = JumpHeight;
            this.Gravity = Gravity;

        }

        public Vector3 GetVector(MovementAction[] move)
        {
            Vector3 vec = new Vector3();
            foreach (var item in move)//more stuff needed maybe idk
            {
                switch (item)
                {
                    case MovementAction.Jump:
                        vec.y = JumpHeight;
                        break;
                    case MovementAction.Right:
                        vec.x = WalkSpeed;
                        DirFacing = 0;
                        UnityEngine.Debug.Log("pluh");
                        break;
                    case MovementAction.Left:
                        vec.x = -WalkSpeed;
                        DirFacing = 0;
                        break;
                    case MovementAction.Up:
                        //how do we want to do crouching and like looking up or smthn
                        DirFacing = 1;
                        break;
                    case MovementAction.Down:
                        //crouch
                        DirFacing = 2;
                        break;
                }
            }
            
            return vec;
        }



    }
}