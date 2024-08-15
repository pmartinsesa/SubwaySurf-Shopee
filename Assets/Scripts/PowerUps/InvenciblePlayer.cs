using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.PowerUps
{
    public class InvenciblePlayer : PowerUpsBase
    {
        private Color DEFAULT_COLOR = Color.white;

        [Header("SpeedUp Settings")]
        public Color InvencibleColor;

        protected override void StartPowerUp()
        {
            MovementHelper.Instance.ChangeStateIsInvencible();
            ChangePlayerColor(InvencibleColor);
            base.StartPowerUp();
        }

        protected override void EndPowerUp()
        {
            MovementHelper.Instance.ChangeStateIsInvencible();
            ChangePlayerColor(DEFAULT_COLOR);
        }

        private void ChangePlayerColor(Color color)
        {
            MovementHelper.Instance.gameObject.GetComponent<Renderer>().material.color = color;
        }
    }
}
