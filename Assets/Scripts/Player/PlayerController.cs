using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        public float lerpTime;
        
        private Vector3 _pastPosition;

        private void Awake()
        {
            _pastPosition = transform.position;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Debug.Log("_pastPosition " + _pastPosition.x);
                Debug.Log("click " + Input.mousePosition.x);

                if (Input.GetAxis("Mouse X") < 0)
                {
                    MoveByXPosition(Input.mousePosition.x - _pastPosition.x);
                }
                if (Input.GetAxis("Mouse X") > 0)
                {
                    MoveByXPosition(Input.mousePosition.x - _pastPosition.x);
                }

                                
            }

        }

        private void MoveByXPosition(float newPosition)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                new Vector3(newPosition, transform.position.y, transform.position.z),
                lerpTime * Time.deltaTime
            );

            _pastPosition = new Vector3(newPosition, transform.position.y, transform.position.z);
        }
    }
}