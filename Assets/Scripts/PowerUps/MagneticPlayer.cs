using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.PowerUps
{
    public class MagneticPlayer : PowerUpsBase
    {
        private Color DEFAULT_COLOR = Color.white;

        [Header("Magnetic Settings")]
        public float sphereColliderSize;
        public Color MagneticColor;

        private Vector3 _defaultScale;
        private GameObject _coinColector;

        private void Start()
        {
            _coinColector = GameObject.FindWithTag("CoinCollector");
            _defaultScale = _coinColector.transform.localScale;
        }

        protected override void StartPowerUp()
        {
            _coinColector.transform.localScale = new Vector3(sphereColliderSize, sphereColliderSize, sphereColliderSize);
            ChangePlayerColor(MagneticColor);
            base.StartPowerUp();
        }

        protected override void EndPowerUp()
        {
            ChangePlayerColor(DEFAULT_COLOR);
            _coinColector.transform.localScale = _defaultScale;
        }

        private void ChangePlayerColor(Color color)
        {
            MovementHelper.Instance.gameObject.GetComponent<Renderer>().material.color = color;
        }
    }
}
