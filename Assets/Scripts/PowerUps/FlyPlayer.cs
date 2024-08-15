using Assets.Scripts.Player;
using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts.PowerUps
{
    public class FlyPlayer : PowerUpsBase
    {
        [Header("Fly Player Settings")]
        public float height;

        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = PlayerController.Instance.gameObject.transform;
        }

        protected override void StartPowerUp()
        {
            _playerTransform.DOMoveY(height, 1);
            base.StartPowerUp();
        }

        protected override void EndPowerUp()
        {
            _playerTransform.DOMoveY(.3f, .5f);
        }
    }
}
