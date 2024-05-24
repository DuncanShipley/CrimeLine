using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;


namespace Assets.Code.Fighting.CharacterControl
{
    public class SeizureActionManager : PlayerActionManager
    {
        protected override MovementManager manager
        {
            get { return new MovementManager(10,3.5f,10.0f);}
        } 
        
    }
}