using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        private const float GROUND_BOUNDARIES = 5f;

        [Header("Movement Settings")]
        public float speed;
        public float staticVelocity;

        private Vector3 _pastPosition;
        private Rigidbody _rigdbody;
        private bool _gameHasStarted = false;

        private void Awake()
        {
            _pastPosition = transform.position;
            _rigdbody = gameObject.GetComponent<Rigidbody>();
        }

        public void StartRun()
        {
            _rigdbody.velocity = Vector3.forward * staticVelocity;
            _gameHasStarted = true;
        }

        private void Update()
        {
            if (!_gameHasStarted)
                return;

            if (Input.GetMouseButton(0))
            {
                MoveByXPosition(Input.mousePosition.x - _pastPosition.x);
                _pastPosition = Input.mousePosition;                    
            }
        }

        private void MoveByXPosition(float movementIntensity)
        {
            var newPosition = transform.position;
            newPosition += Vector3.right * Time.deltaTime * movementIntensity * speed;
            newPosition.x = verifyBounndaries(newPosition.x);

            transform.position = newPosition;
        }

        private float verifyBounndaries(float xPosition)
        {
            if (xPosition > GROUND_BOUNDARIES)
                return GROUND_BOUNDARIES;
            if (xPosition < -GROUND_BOUNDARIES)
                return -GROUND_BOUNDARIES;
            return xPosition;
        }
    }
}