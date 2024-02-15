using System.Collections;
using UnityEngine;

namespace Assets.Code.Fighting.EnemyManagers
{
    public class EnemyData : MonoBehaviour
    {


        private static EnemyData instance;

        // Use this for initialization
        void Start()
        {

            if (instance != null)
                instance = this;
           
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}