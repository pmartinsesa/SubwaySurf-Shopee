using UnityEngine;

namespace Assets.Scripts.Player
{
    public class MovementHelper : MonoBehaviour
    {
        [Header("Lerp Settings")]
        public float lerpTime;
        public Transform target;

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, target.position, lerpTime * Time.deltaTime);
        }
    }
}