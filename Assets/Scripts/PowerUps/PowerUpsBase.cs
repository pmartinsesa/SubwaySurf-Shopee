using Assets.Scripts.CollectableItems;
using Assets.Scripts.Player;
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
            MovementHelper.Instance.OnGetPower();
            Invoke(nameof(EndPowerUp), duration);
        }

        protected virtual void EndPowerUp()
        {

        }
    }
}
