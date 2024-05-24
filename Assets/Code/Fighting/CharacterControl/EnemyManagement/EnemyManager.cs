using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Collections.Immutable;
using Assets.Code.Fighting.CharacterControl;
using Assets.Code.Fighting.CharacterControl.EnemyManagement.EnemyAis;
using Code.Fighting.Utils;


namespace Assets.Code.Fighting.CharacterControl.EnemyManagement {
    public class EnemyManager : MonoBehaviour
    {
        
        private List<Enemy> ActiveChildren;
        private EnemyType[] InitialEnemies;

        private GameObject playerObject;
        private Collider playerCollider;



        public EnemyManager(params EnemyType[] InitialEnemies)
        {
            this.InitialEnemies = InitialEnemies;
            
        }

        private void Awake()
        {
            ActiveChildren = new List<Enemy>();
        }

        public EnemyManager()
        {
            InitialEnemies = new EnemyType[]
            {
                EnemyType.Ryu
            };
            
        }


        private void Start()
        {
            playerObject = FindObjectOfType<PlayerActionManager>().gameObject;
            playerCollider = playerObject.GetComponent<Collider>();
            SpawnEnemies(InitialEnemies);
            FindObjectOfType<Cameracontroller>().AddP2(ActiveChildren[0].actor);
            
        }

        private void Update()
        {
           print("num active children:" + ActiveChildren.Count);
            foreach (Enemy enemy in ActiveChildren)
            {
                EnemyAiInput input = BuildInputs(enemy, playerCollider);
                (PlayerAction[], MovementAction[]) action = enemy.brain.Output(input);
                enemy.actionManager.TryAction(action.Item1);
                enemy.actionManager.TryMoveAction(action.Item2);
                

            }
        }

        private EnemyAiInput BuildInputs(Enemy enemy, Collider playerPosition)
        {
            float distanceToPC = MathUtils.EuclideanNorm3(enemy.actor.transform.position, playerPosition.bounds.center);
            bool playerTouchingGround = playerPosition.TouchingGround();
            bool touchingGround = enemy.collider.TouchingGround();
            AnimatorStateInfo animationState = enemy.animator.GetCurrentAnimatorStateInfo(0);
            Vector3 pcPosition = playerPosition.bounds.center;
  
            return new EnemyAiInput
                (
                    distanceToPC, 
                    playerTouchingGround,
                    touchingGround,
                    animationState,
                   pcPosition
                );
        }

        public void SpawnEnemies(EnemyType[] enemies)
        {
            foreach (EnemyType enemy in enemies) {
                if (Constants.instance.enemyPrefabs.TryGetValue(enemy, out GameObject result))
                {
                    ActiveChildren.Add(new Enemy(
                        enemy,
                        Instantiate(result, gameObject.transform, true)
                     ));

                }
                else
                {
                    throw new System.Exception(string.Format("Enemy of type {0} does not exist", enemy.ToString()));
                }
            }
        }

    }


    public enum EnemyType
    {
        Ken,
        Ryu
    }

    struct Enemy
    {
        public EnemyType type;
        public GameObject actor;
        public EnemyAI brain;
        public Collider collider;
        public PlayerActionManager actionManager;
        public Animator animator;

        public Enemy(EnemyType type, GameObject actor)
        {
            this.type = type;
            this.actor = actor;
            brain = Constants.instance.enemyBrains.TryGetValue(type, out brain) ? brain : null;
            collider = actor.GetComponent<Collider>();
            actionManager = actor.GetComponent<PlayerActionManager>();
            animator = actor.GetComponent<Animator>();
        }
    }

    public record EnemyAiInput    {
        public float DistanceToPC;
        public bool  PCCanJump;
        public bool  TouchingGround;
        public AnimatorStateInfo AnimationState;
        public Vector3 PCPosition;

        public EnemyAiInput(float distanceToPC, bool PCCanJump, bool TouchingGround, AnimatorStateInfo animationState, Vector3 PCPosition)
        {
            this.DistanceToPC = distanceToPC;
            this.PCCanJump = PCCanJump;
            this.TouchingGround = TouchingGround;
            this.AnimationState = animationState;
            this.PCPosition = PCPosition;

        }
    }

}
