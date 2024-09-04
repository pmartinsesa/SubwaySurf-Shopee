using Assets.Scripts.Managers;
using Assets.Scripts.Player;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.CollectableItems
{
    public class Coin : CollectableBase
    {
        [Header("Animation settings")]
        public float coinScale;
        public float animationduration;
        public Ease animationtype;

        [Header("Particle system settings")]
        public ParticleSystem coinParticle;

        private bool _hasToBringCoing = false;

        public void Start()
        {
            onCollectEvent.AddListener(CollectableManager.Instance.addCoin); 
        }

        private void OnEnable()
        {
            gameObject.transform.DOScale(coinScale, animationduration).From().SetEase(animationtype);
        }

        private void Update()
        {
            if (!_hasToBringCoing) return;
            transform.position = Vector3.Lerp(transform.position, MovementHelper.Instance.gameObject.transform.position, 10f * Time.deltaTime);
        }
        public override void onCollect()
        {
            _hasToBringCoing = true;
            coinParticle.transform.parent = null;
            coinParticle.Play();
            base.onCollect();
        }
    }
}
