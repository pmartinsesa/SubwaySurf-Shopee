using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.PowerUps
{
    public class SpeedUpPlayer : PowerUpsBase
    {
        [Header("SpeedUp Settings")]
        public int speedUpVelocity;

        protected override void StartPowerUp()
        {
            PlayerController.Instance.SetVelocity(speedUpVelocity);
            base.StartPowerUp();
        }

        protected override void EndPowerUp()
        {
            PlayerController.Instance.SetVelocity(20f);
        }
    }
}
