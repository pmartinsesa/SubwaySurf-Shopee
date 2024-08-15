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
            Invoke(nameof(EndPowerUp), duration);
        }

        protected override void EndPowerUp()
        {
            PlayerController.Instance.StartRun();
        }
    }
}
