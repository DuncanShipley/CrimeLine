using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Code.Fighting.CharacterControl
{
    public class SeizureActor : PlayerActionManager
    {
        [SerializeField] Animator anim;
        [SerializeField] Rigidbody body;
        MovementManager manager;
        public GameObject MeleeSide;
        public GameObject MeleeUp;
        public GameObject MeleeDown;
        public GameObject RangeSide;
        public GameObject RangeUp;
        public GameObject RangeDown;
        [SerializeField] private AudioClip groundSpikeSFX;
        [SerializeField] private AudioClip uppercutSFX;
        [SerializeField] private AudioClip whipSFX;
        [SerializeField] private AudioClip knifeSFX;
        [SerializeField] private AudioClip shieldPushSFX;
        [SerializeField] private AudioClip ballSFX;

        public override void MeleeSideAttack()
        {
            SFXManager.instance.PlaySFXClip(groundSpikeSFX, transform, 1f);
            Instantiate(this.MeleeSide, gameObject.transform, false);
        }

        public override void MeleeDownAttack()
        {
            SFXManager.instance.PlaySFXClip(uppercutSFX, transform, 1f);
            Instantiate(this.MeleeDown, gameObject.transform, false);
        }

        public override void MeleeUpAttack()
        {
            SFXManager.instance.PlaySFXClip(whipSFX, transform, 1f);
            Instantiate(this.MeleeUp, gameObject.transform, false);
        }

        public override void RangeSideAttack()
        {
            SFXManager.instance.PlaySFXClip(knifeSFX, transform, 0.3f);
            Instantiate(this.RangeSide, gameObject.transform, false);
        }

        public override void RangeUpAttack()
        {
            SFXManager.instance.PlaySFXClip(ballSFX, transform, 0.3f);
            Instantiate(this.RangeUp, gameObject.transform, false);
        }

        public override void RangeDownAttack()
        {
            SFXManager.instance.PlaySFXClip(shieldPushSFX, transform, 3f);
            Instantiate(this.RangeDown, gameObject.transform, false);
        }
        private void DelAttack()
        {
            gameObject.GetComponentInChildren<Attack>().DeleteSelf();
        }
    }
}