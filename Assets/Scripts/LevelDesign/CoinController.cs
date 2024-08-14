using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.LevelDesign
{
    public class CoinController : MonoBehaviour
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
