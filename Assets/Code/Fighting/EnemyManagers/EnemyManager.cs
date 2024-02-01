using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Collections.Immutable;
using Assets.Code.Fighting.EnemyManagers.EnemyAis;

namespace Assets.Code.Fighting.EnemyManagers {
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private static readonly Transform SPAWNING_LOCATION = new GameObject().transform;
        [SerializeField] private static GameObject KenPrefab;
        [SerializeField] private static GameObject RyuPrefab;

        private List<Enemy> ActiveChildren;
        private EnemyType[] InitialEnemies;

        public static readonly ImmutableDictionary<EnemyType, GameObject> enemyPrefabs = new Dictionary<EnemyType, GameObject>
        {
            {EnemyType.Ken, KenPrefab },
            {EnemyType.Ryu, RyuPrefab }
        }.ToImmutableDictionary<EnemyType, GameObject>();

        public static readonly ImmutableDictionary<EnemyType, EnemyAI> enemyBrains = new Dictionary<EnemyType, EnemyAI>
        {
            {EnemyType.Ken, new KenAI() },
            {EnemyType.Ryu, new RyuAI() }
        }.ToImmutableDictionary<EnemyType, EnemyAI>();


        public EnemyManager(params EnemyType[] InitialEnemies)
        {
            this.InitialEnemies = InitialEnemies;
            SpawnEnemies(InitialEnemies);
        }


        private void Start()
        {

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
            bool PCTouchingGround;
            bool touchingGround;
            AnimatorStateInfo animation = enemy.TryGetComponent<Animator>(out Animator comp) ? comp.GetCurrentAnimatorStateInfo(0) : throw new MissingComponentException("Enemy animator component not found");
            float PCPosition;
  
            return new EnemyAiInput();
            
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
        float DistanceToPC;
        bool  PCCanJump;
        bool  TouchingGround;
        AnimatorStateInfo AnimationState;
        Vector3 PCPosition;
    }

}
