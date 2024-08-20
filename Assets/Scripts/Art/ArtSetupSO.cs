using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Art
{
    [CreateAssetMenu(fileName = "ScriptableObject.asset", menuName = "ScriptableObject/ArtSetupSO")]
    public class ArtSetupSO : ScriptableObject
    {
        public List<GameObject> art;
        public Color objectColor;
        public Color groundColor;
    }
}
