using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.CollectableItems
{
    public abstract class CollectableBase : MonoBehaviour
    {
        [Header("Collectable Settings")]
        public UnityEvent onCollectEvent;
        public string tagToCompare;
        public float timeToDeath = 0f;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag(tagToCompare))
            {
                onCollect();
                Invoke(nameof(OnDesativate), timeToDeath);
                Destroy(gameObject, 5f);
            }
        }

        public virtual void onCollect()
        {
            onCollectEvent.Invoke();
        }

        private void OnDesativate()
        {
            gameObject.SetActive(false);
        }
    }
}
