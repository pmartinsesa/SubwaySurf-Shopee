using Assets.Scripts.Art;
using Assets.Scripts.LevelDesign;
using Assets.Scripts.Player;
using Assets.Scripts.SubwaySurfShoppe.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.Managers
{
    public class LevelManager : Singleton<LevelManager>
    {
        [Header("Level settings")]
        public List<LevelSetupSO> levelSetup;
        public GameObject container;

        [Header("Animation settings")]
        public float renderMapDuration;
        public float groundAnimationDuration;
        public float groundAnimationScale;
        public Ease easeType;

        private GameObject _spawnedPiece;
        private Transform _endPiecePosition;
        private LevelSetupSO _currentLevel;
        private int _currentLevelIndex = 0;
        private List<GameObject> piecesToSpawn = new List<GameObject>();
        private bool _isSpawning = false;

        private void Start()
        {
            _isSpawning = true;
            CreateLevel();
            StartCoroutine(SetPiecesAsActive());
        }

        private void Update()
        {
            if (PlayerController.Instance._gameHasStarted)
                return;

            if (Input.GetKeyDown(KeyCode.Space) && !_isSpawning)
            {
                _isSpawning = true;
                _currentLevelIndex = _currentLevelIndex + 1 >= levelSetup.Count ? 0 : _currentLevelIndex + 1;
                DestroyOldLevel();
                CreateLevel();
                StartCoroutine(SetPiecesAsActive());
            }
        }

        private void CreateLevel()
        {
            _currentLevel = levelSetup[_currentLevelIndex];
            _currentLevel.levelContainer = container;
            SetupLevel();
        }

        private IEnumerator SetPiecesAsActive()
        {
            foreach(GameObject spawnableObject in piecesToSpawn) 
            { 
                yield return new WaitForSeconds(renderMapDuration);
                spawnableObject.gameObject.SetActive(true);
                spawnableObject.transform
                    .DOScaleX(groundAnimationScale, groundAnimationDuration)
                    .From()
                    .SetEase(easeType);
            }

            _isSpawning = false;
        }

        private void DestroyOldLevel()
        {
            foreach (Transform child in container.transform)
            {
                Destroy(child.gameObject);
            }

            piecesToSpawn.Clear();
        }

        private void SetupLevel()
        {
            CreateLevelBegin();
            CreatePieces(_currentLevel.piecesCount, false);
            CreateLevelEnd();
        }

        private void CreateLevelBegin()
        {
            _spawnedPiece = InstanciateNewPiece(_currentLevel.startPiece, _currentLevel.levelContainer);
            CreatePieces(_currentLevel.beginPiecesCount - 1);
        }

        private void CreateLevelEnd()
        {
            CreatePieces(_currentLevel.endPiecesCount);
            SetupPiece(_currentLevel.finalPiece);
            CreatePieces(_currentLevel.endPiecesCount);
        }

        private void CreatePieces(int countOfPieces, bool isBlankPiece = true)
        {
            for (int i = 0; i < countOfPieces; i++)
            {
                MakePiece(isBlankPiece ? _currentLevel.startPiece : GetRandomPiece());
            }
        }

        private void MakePiece(GameObject piece)
        {
            _endPiecePosition = _spawnedPiece.GetComponent<LevelPieceBase>().endPiece;
            SetupPiece(piece);
        }

        private GameObject GetRandomPiece()
        {
            return _currentLevel.levelPieces[Random.Range(0, _currentLevel.levelPieces.Count - 1)];
        }

        private void SetupPiece(GameObject piece)
        {
            _spawnedPiece = InstanciateNewPiece(piece, _currentLevel.levelContainer);
            _spawnedPiece.transform.position = _endPiecePosition.position;
        }

        private GameObject InstanciateNewPiece(GameObject piece, GameObject parent)
        {
            var newPiece = Instantiate(piece, parent.transform);
            newPiece.GetComponentInChildren<ArtSetup>().SetPieceArt(_currentLevel.artSetupModel);
            newPiece.SetActive(false);

            piecesToSpawn.Add(newPiece);

            return newPiece;
        }
    }
}
