using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        public List<Transform> positions;
        public float duration = 1f;

        private int _currentTarget = 0;

        private void Start()
        {
            StartCoroutine(StartMoviment());
        }

        private IEnumerator StartMoviment()
        {
            while (true)
            {
                var currentPosition = transform.position;

                for (var time = 0f; time < duration; time += Time.deltaTime)
                {
                    transform.position = Vector3.Lerp(currentPosition, positions[_currentTarget].position, (time / duration));
                    time += Time.deltaTime;
                    yield return null;
                }

                _currentTarget = SetNextTargetIndex();
                yield return null;
            }
        }

        private int SetNextTargetIndex()
        {
            var currentIndex = _currentTarget + 1;
            return currentIndex >= positions.Count ? 0 : currentIndex;
        }
    }
}
