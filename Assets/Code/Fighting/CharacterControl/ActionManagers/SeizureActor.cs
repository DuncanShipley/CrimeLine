using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Code.Fighting.CharacterControl
{
    public class SeizureActor : PlayerActionManager
    {
        public Animator anim
        {set; get;}
        public Rigidbody body
        {set; get;}
        public MovementManager manager
        {set; get;}
        public GameObject MeleeSide;
        public GameObject MeleeUp;
        public GameObject MeleeDown;
        public GameObject RangeSide;
        public GameObject RangeUp;
        public GameObject RangeDown;
        [SerializeField] private AudioClip MSideSFX;
        [SerializeField] private AudioClip MDownSFX;
        [SerializeField] private AudioClip MUpSFX;
        [SerializeField] private AudioClip RSideSFX;
        [SerializeField] private AudioClip RDownSFX;
        [SerializeField] private AudioClip RUpSFX;


        public override void MeleeSideAttack()
        {
            SFXManager.instance.PlaySFXClip(MSideSFX, transform, 1f);
            Instantiate(this.MeleeSide, gameObject.transform, false);
        }

        public override void MeleeDownAttack()
        {
            SFXManager.instance.PlaySFXClip(MDownSFX, transform, 1f);
            Instantiate(this.MeleeDown, gameObject.transform, false);
        }

        public override void MeleeUpAttack()
        {
            SFXManager.instance.PlaySFXClip(MUpSFX, transform, 1f);
            Instantiate(this.MeleeUp, gameObject.transform, false);
        }

        public override void RangeSideAttack()
        {
            SFXManager.instance.PlaySFXClip(RSideSFX, transform, 0.3f);
            Instantiate(this.RangeSide, gameObject.transform, false);
        }

        public override void RangeUpAttack()
        {
            SFXManager.instance.PlaySFXClip(RUpSFX, transform, 0.3f);
            Instantiate(this.RangeUp, gameObject.transform, false);
        }

        public override void RangeDownAttack()
        {
            SFXManager.instance.PlaySFXClip(RDownSFX, transform, 3f);
            Instantiate(this.RangeDown, gameObject.transform, false);
        }

        public override void Block()
        {
            blocking = true;
            
            //todo might what to make movemanger check if blocking before adding kb
        }
        public override void DeBlock()
        {
            blocking = false;
        }

        private void DelAttack()
        {
            if (gameObject.GetComponentInChildren<Attack>() != null)
                gameObject.GetComponentInChildren<Attack>().DeleteSelf();
            stunned = false;
        }
        private void Unstunn()
        {
            stunned = false;
        }
        private void NexTac()
        {
            
        }

    }
}