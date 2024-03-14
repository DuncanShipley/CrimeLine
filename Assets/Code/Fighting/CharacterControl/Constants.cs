using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Collections.Immutable;
using Assets.Code.Fighting.CharacterControl.EnemyManagement.EnemyAis;
using Assets.Code.Fighting.CharacterControl.EnemyManagement;
using UnityEngine.UI;


namespace Assets.Code.Fighting.CharacterControl
{
    public class Constants: MonoBehaviour
    {

        public static Constants instance;

        public GameObject Hadouken;
        public GameObject RyuPunch;
        public GameObject KenPunch;
        public GameObject KenPrefab;
        public GameObject RyuPrefab;
        public Slider EnemySlider;

        public ImmutableDictionary<EnemyType, GameObject> enemyPrefabs;

        public readonly ImmutableDictionary<EnemyType, EnemyAI> enemyBrains = new Dictionary<EnemyType, EnemyAI>
        {
            {EnemyType.Ken, new KenAI() },
            {EnemyType.Ryu, new RyuAI() }
        }.ToImmutableDictionary<EnemyType, EnemyAI>();

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);

            enemyPrefabs = new Dictionary<EnemyType, GameObject>
                    {
                        {EnemyType.Ken, KenPrefab },
                        {EnemyType.Ryu, RyuPrefab }
                    }.ToImmutableDictionary<EnemyType, GameObject>();
        }

    }
}