using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.CollectableItems
{
    public class Coin : CollectableBase
    {
        private bool _hasToBringCoing = false;
        private void Update()
        {
            if (!_hasToBringCoing) return;
            transform.position = Vector3.Lerp(transform.position, MovementHelper.Instance.gameObject.transform.position, 10f * Time.deltaTime);
        }
        public override void onCollect()
        {
            _hasToBringCoing = true;
            base.onCollect();
        }
    }
}
