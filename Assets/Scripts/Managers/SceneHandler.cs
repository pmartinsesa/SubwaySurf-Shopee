using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class SceneHandler : MonoBehaviour
    {
        public PlayerController playerController;
        public GameObject canvas;

        public void onPlay()
        {
            canvas.SetActive(false);
            playerController.StartRun();
        }
    }
}
