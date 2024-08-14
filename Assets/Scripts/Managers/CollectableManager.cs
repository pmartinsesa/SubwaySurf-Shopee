using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class CollectableManager : MonoBehaviour
    {
        private int coinCounter = 0;

        public void addCoin()
        {
            coinCounter += 1;
            Debug.Log("Moedas = " + coinCounter);
        }
    }
}
