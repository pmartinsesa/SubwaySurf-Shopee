using Assets.Scripts.Art;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.LevelDesign
{
    [CreateAssetMenu(fileName = "ScriptableObject.asset", menuName = "ScriptableObject/LevelSetupSO")]
    public class LevelSetupSO : ScriptableObject
    {
        [Header("Level Settings")]
        public GameObject levelContainer;
        public GameObject startPiece;
        public GameObject finalPiece;
        public List<GameObject> levelPieces;

        [Header("Size Settings")]
        public int beginPiecesCount;
        public int piecesCount;
        public int endPiecesCount;

        [Header("Art Settings")]
        public ArtSetupSO artSetupModel;
    }
}
