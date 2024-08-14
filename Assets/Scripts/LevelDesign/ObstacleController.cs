using UnityEngine;

namespace Assets.Scripts.LevelDesign
{
    public class ObstacleController : MonoBehaviour
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

        private void Start()
        {
            for (var zPosition = initialObstaclePosition; zPosition <= finalObstaclePosition; zPosition += Random.Range(minObstacleGap, maxObstacleGap))
            {
                var obstacleScale = Random.Range(minObstacleXScale, maxObstacleXScale);
                var xPosition = Random.Range(LEFT_BOUNDARIES, RIGHT_BOUNDARIES);
                InstatiateObstaclePrefab(
                    new Vector3(obstacleScale, 1f, 1f),
                    new Vector3(xPosition, -.5f, zPosition)
                );
            }
        }

        private void InstatiateObstaclePrefab(Vector3 obstacleScale, Vector3 obstaclePosition)
        {
            obstaclePrefab.transform.localScale = obstacleScale;
            obstaclePrefab.transform.position = obstaclePosition;

            Instantiate(obstaclePrefab, levelObject.transform);
        }
    }
}
