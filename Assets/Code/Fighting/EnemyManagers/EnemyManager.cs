using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Collections.Immutable;
using Assets.Code.Fighting.EnemyManagers.EnemyAis;

namespace Assets.Code.Fighting.EnemyManagers {
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private readonly Transform SPAWNING_LOCATION = new GameObject().transform;
        [SerializeField] public static GameObject KenPrefab;
        [SerializeField] public static GameObject RyuPrefab;


        private List<Enemy> ActiveChildren;
        private EnemyType[] InitialEnemies;




        public EnemyManager(params EnemyType[] InitialEnemies)
        {
            this.InitialEnemies = InitialEnemies;
            
        }


        private void Start()
        {
            SpawnEnemies(InitialEnemies);

        }

        private void Update()
        {
            foreach (Enemy enemy in ActiveChildren)
            {
                EnemyAiInput input = BuildInputs(enemy.actor, FindObjectOfType<PCControl>().gameObject.transform);
                (EnemyAction, EnemyMoveAction[]) action = enemy.brain.Output(input);
                enemy.actor.GetComponent<EnemyActionManager>().TryAction(action.Item1);
                enemy.actor.GetComponent<EnemyActionManager>().TryMoveAction(action.Item2);

            }
        }

        private EnemyAiInput BuildInputs(GameObject enemy, Transform playerPosition)
        {
            float distanceToPC = MathUtils.EuclideanNorm3(enemy.transform.position, playerPosition.position);
            bool playerTouchingGround = playerPosition.isTouching("ground");
            bool touchingGround = enemy.transform.isTouching("ground");
            AnimatorStateInfo animation = enemy.TryGetComponent<Animator>(out Animator comp) ? comp.GetCurrentAnimatorStateInfo(0) : throw new MissingComponentException("Enemy animator component not found");
            Vector3 PCPosition = playerPosition.position;
  
            return new EnemyAiInput
                (
                    distanceToPC, 
                    playerTouchingGround,
                    touchingGround,
                    animation,
                    PCPosition
                );
        }

     



        public void SpawnEnemies(EnemyType[] enemies)
        {
            foreach (EnemyType enemy in enemies) {
                if (enemyPrefabs.TryGetValue(enemy, out GameObject result))
                {
                    ActiveChildren.Add(new Enemy(
                        enemy,
                        Instantiate(result, SPAWNING_LOCATION, true)
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

        public Enemy(EnemyType type, GameObject actor)
        {
            this.type = type;
            this.actor = actor;
            this.brain = EnemyManager.enemyBrains.TryGetValue(type, out brain) ? brain : null;
            
        }
    }

    //TODO make a better action management system
    public enum EnemyAction
    {
        KenHadouken,
        KenPunch,
        KenUppercut,
        RyuPunch,
        RyuUppercut,
        RyuHadouken,
    }

    public enum EnemyMoveAction
    {
        Right,
        Left,
        Jump,
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
