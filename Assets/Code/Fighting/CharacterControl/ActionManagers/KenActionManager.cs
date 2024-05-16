namespace Assets.Code.Fighting.CharacterControl
{

    public class KenActionManager : PlayerActionManager
    {
        protected override MovementManager manager
        {
            get { return new MovementManager(10,3.5f,10.0f);}
        }
        
    }
}