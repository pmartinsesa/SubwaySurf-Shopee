using Assets.Scripts.CollectableItems;
using UnityEngine;

namespace Assets.Scripts.PowerUps
{
    public abstract class PowerUpsBase : CollectableBase
    {
        [Header("PowerUp Settings")]
        public float duration;

        private void Awake()
        {
            onCollectEvent.AddListener(StartPowerUp);
        }

        public override void onCollect()
        {
            base.onCollect();
        }

        protected virtual void StartPowerUp()
        {
            Invoke(nameof(EndPowerUp), duration);
        }

        protected virtual void EndPowerUp()
        {

        }
    }
}
