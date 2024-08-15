using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.CollectableItems
{
    public class Coin : MonoBehaviour
    {
        public UnityEvent onCollect;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                onCollect.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
