using System.Collections;
using UnityEngine;

namespace Assets.Code.Fighting
{
    public abstract class Attack
    {
        public virtual int damage { get; set;}
    }


    public class PunchAttack : Attack
    {
        public override int damage
        { 
            get { return 10; }

        }
    }
}