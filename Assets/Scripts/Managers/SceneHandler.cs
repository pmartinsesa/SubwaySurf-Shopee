using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class SceneHandler : MonoBehaviour
    {
        [Header("Scene Settings")]
        public GameObject canvas;

        public void onPlay()
        {
            canvas.SetActive(false);
            PlayerController.Instance.StartRun();
        }
    }
}
