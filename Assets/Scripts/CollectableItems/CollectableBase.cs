using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.CollectableItems
{
    public abstract class CollectableBase : MonoBehaviour
    {
        [Header("Collectable Settings")]
        public UnityEvent onCollectEvent;
        public string tagToCompare;

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag(tagToCompare))
            {
                onCollect();
                gameObject.SetActive(false);
                Destroy(gameObject, 5f);
            }
        }

        public virtual void onCollect()
        {
            onCollectEvent.Invoke();
        }
    }
}
