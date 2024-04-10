// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// using UnityEngine;
// namespace Assets.Code.Fighting.CharacterControl
// {
//     public abstract class PlayerActionManager : MonoBehaviour
//     {
//         protected Animator anim;
//         protected Rigidbody body;
//         protected MovementManager manager;
//         protected bool stunned = false;
//         protected float dir;
//         public void TryAction(PlayerAction[] action)
//         {
//             dir = manager.DirFacing;
//             foreach (var Item in action)
//             {
//                 switch(Item)
//                 {
//                     case PlayerAction.Block:
//                         //idk how ima do block yet
//                         break;
//                     case PlayerAction.MeleeAttack:
//                         switch(dir)
//                         {
//                             case 0:
//                                 anim.SetTrigger("MeleeSide");
//                                 MeleeSideAttack();
//                                 break;
//                             case 1:
//                                 anim.SetTrigger("MeleeUp");
//                                 MeleeDownAttack();
//                                 break;
//                             case 2:
//                                 anim.SetTrigger("MeleeDown");
//                                 MeleeUpAttack();
//                                 break;
//                         }
//                         break;
//                     case PlayerAction.RangeAttack:
//                         switch (dir)
//                         {
//                             case 0:
//                                 anim.SetTrigger("RangeSide");
//                                 RangeSideAttack();
//                                 break;
//                             case 1:
//                                 anim.SetTrigger("RangeUp");
//                                 RangeDownAttack();
//                                 break;
//                             case 2:
//                                 anim.SetTrigger("RangeDown");
//                                 RangeUpAttack();
//                                 break;
//                         }
//                         break;
//                 }
//             }
//         }

//         public void TryMoveAction(MovementAction[] movement)
//         {
//             body.AddForce(manager.GetVector(movement));
//         }

//         public abstract void MeleeSideAttack();

//         public abstract void MeleeDownAttack();

//         public abstract void MeleeUpAttack();

//         public abstract void RangeSideAttack();

//         public abstract void RangeDownAttack();

//         public abstract void RangeUpAttack();


//     }
// }
