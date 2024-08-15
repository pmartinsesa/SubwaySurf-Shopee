using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.PowerUps
{
    public class InvenciblePlayer : PowerUpsBase
    {
        private Color DEFAULT_COLOR = new Color(1f, 1f, 1f, 1f);

        [Header("SpeedUp Settings")]
        public Color InvencibleColor;

        protected override void StartPowerUp()
        {
            MovementHelper.Instance.ChangeStateIsInvencible();
            ChangePlayerColor(InvencibleColor);
            Invoke(nameof(EndPowerUp), duration);
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
