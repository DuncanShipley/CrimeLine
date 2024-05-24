using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Fighting.CharacterControl.EnemyManagement
{
    public class EnemyHealthScript : HealthScript
    {
        private void Awake()
        {
            slider = Constants.instance.EnemySlider;
        }

        
    }
}