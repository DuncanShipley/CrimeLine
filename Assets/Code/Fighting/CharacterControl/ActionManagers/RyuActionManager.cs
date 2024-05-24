using UnityEditor;
using UnityEngine;


namespace Assets.Code.Fighting.CharacterControl
{

    public class RyuActionManager : PlayerActionManager
    {
        protected override MovementManager manager
        {
            get { return new MovementManager(10,3.5f,10.0f);}
        } 
    }
}