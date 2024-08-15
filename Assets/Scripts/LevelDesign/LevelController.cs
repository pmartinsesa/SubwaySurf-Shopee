using UnityEngine;

namespace Assets.Scripts.LevelDesign
{
    public class LevelController : MonoBehaviour
    {
        private const float LEFT_BOUNDARIES = -5f;
        private const float RIGHT_BOUNDARIES = 5f;

        [Header("Size Settings")]
        public float minObstacleXScale = 2f;
        public float maxObstacleXScale = 4f;

        [Header("Position Settings")]
        public float initialObstaclePosition = 10f;
        public float finalObstaclePosition = 270f;
        public float minObstacleGap = 5f;
        public float maxObstacleGap = 20f;

        [Header("Game Object Settings")]
        public GameObject levelObject;
        public GameObject obstaclePrefab;
        public GameObject coinPrefab;

        private void Start()
        {
            for (var zPosition = initialObstaclePosition; zPosition <= finalObstaclePosition; zPosition += Random.Range(minObstacleGap, maxObstacleGap))
            {
                var obstacleScale = Random.Range(minObstacleXScale, maxObstacleXScale);
                var xObstaclePosition = Random.Range(LEFT_BOUNDARIES, RIGHT_BOUNDARIES);
                InstatiatePrefab(obstaclePrefab, new Vector3(obstacleScale, 1f, 1f), new Vector3(xObstaclePosition, -.5f, zPosition));
                SetCoinPosition(xObstaclePosition, zPosition);
            }
        }

        private void SetCoinPosition(float xObstaclePosition, float zPosition)
        {
            var xCoinPosition = Mathf.Abs(xObstaclePosition - LEFT_BOUNDARIES) < Mathf.Abs(xObstaclePosition - RIGHT_BOUNDARIES) ?
                    (xObstaclePosition - LEFT_BOUNDARIES) / 2 : (xObstaclePosition - RIGHT_BOUNDARIES) / 2;
            InstatiatePrefab(
                coinPrefab,
                new Vector3(1f, 1f, 1f),
                new Vector3(xCoinPosition, 1f, zPosition)
            );
        }

        private void InstatiatePrefab(GameObject prefab, Vector3 scale, Vector3 position)
        {
            prefab.transform.localScale = scale;
            prefab.transform.position = position;
            Instantiate(prefab, levelObject.transform);
        }
    }
}
