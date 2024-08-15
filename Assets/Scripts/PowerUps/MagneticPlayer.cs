using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.PowerUps
{
    public class MagneticPlayer : PowerUpsBase
    {
        private Color DEFAULT_COLOR = Color.white;

        [Header("Magnetic Settings")]
        public GameObject playerCoinCollector;
        public float sphereColliderSize;
        public Color MagneticColor;

        private Vector3 _defaultScale;

        private void Start()
        {
            _defaultScale = playerCoinCollector.transform.localScale;
        }

        protected override void StartPowerUp()
        {
            playerCoinCollector.transform.localScale = new Vector3(sphereColliderSize, sphereColliderSize, sphereColliderSize);
            ChangePlayerColor(MagneticColor);
            base.StartPowerUp();
        }

        protected override void EndPowerUp()
        {
            ChangePlayerColor(DEFAULT_COLOR);
            playerCoinCollector.transform.localScale = _defaultScale;
        }

        private void ChangePlayerColor(Color color)
        {
            MovementHelper.Instance.gameObject.GetComponent<Renderer>().material.color = color;
        }
    }
}
