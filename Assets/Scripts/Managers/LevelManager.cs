using Assets.Scripts.Art;
using Assets.Scripts.LevelDesign;
using Assets.Scripts.Player;
using Assets.Scripts.SubwaySurfShoppe.Core;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class LevelManager : Singleton<LevelManager>
    {
        public List<LevelSetupSO> levelSetup;
        public GameObject container;

        private GameObject _spawnedPiece;
        private Transform _endPiecePosition;
        private LevelSetupSO _currentLevel;
        private int _currentLevelIndex = 0;

        private void Start()
        {
            RenderLevel();
        }


        private void Update()
        {
            if (PlayerController.Instance._gameHasStarted)
                return;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _currentLevelIndex = _currentLevelIndex + 1 >= levelSetup.Count ? 0 : _currentLevelIndex + 1;
                DestroyOldLevel();
                RenderLevel();
            }
        }

        private void RenderLevel()
        {
            _currentLevel = levelSetup[_currentLevelIndex];
            _currentLevel.levelContainer = container;
            InstantiateLevel();
        }

        private void DestroyOldLevel()
        {
            foreach (Transform child in container.transform)
            {
                Destroy(child.gameObject);
            }
        }

        private void InstantiateLevel()
        {
            CreateLevelBegin();
            CreatePieces(_currentLevel.piecesCount, false);
            CreateLevelEnd();
        }

        private void CreateLevelBegin()
        {
            _spawnedPiece = SetupPiece(_currentLevel.startPiece, _currentLevel.levelContainer);
            CreatePieces(_currentLevel.beginPiecesCount - 1);
        }

        private void CreatePieces(int countOfPieces, bool isBlackPieces = true)
        {
            for (int i = 0; i < countOfPieces; i++)
            {
                _endPiecePosition = _spawnedPiece.GetComponent<LevelPieceBase>().endPiece;
                _spawnedPiece = SetupPiece(isBlackPieces ? _currentLevel.startPiece : GetRandomPiece(), _currentLevel.levelContainer);
                _spawnedPiece.transform.position = _endPiecePosition.position;
            }
        }

        private void CreateLevelEnd()
        {
            CreatePieces(_currentLevel.endPiecesCount);
            _spawnedPiece = SetupPiece(_currentLevel.finalPiece, _currentLevel.levelContainer);
            _spawnedPiece.transform.position = _endPiecePosition.position;
            CreatePieces(_currentLevel.endPiecesCount);
        }

        private GameObject GetRandomPiece()
        {
            return _currentLevel.levelPieces[Random.Range(0, _currentLevel.levelPieces.Count - 1)];
        }

        private GameObject SetupPiece(GameObject piece, GameObject parent)
        {
            _spawnedPiece = Instantiate(piece, parent.transform);
            _spawnedPiece.GetComponentInChildren<ArtSetup>().SetPieceArt(_currentLevel.artSetupModel);
            return _spawnedPiece;
        }
    }
}
