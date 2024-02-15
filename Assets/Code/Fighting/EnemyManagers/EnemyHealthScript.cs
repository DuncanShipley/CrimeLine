using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Fighting
{
    public class EnemyHealthScript : HealthScript
    {
        private void Awake()
        {
            slider = EnemyManagers.EnemyConstants.instance.EnemySlider;
        }
        
    }
}