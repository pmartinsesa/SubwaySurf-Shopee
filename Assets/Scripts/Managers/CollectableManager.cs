using Assets.Scripts.SubwaySurfShoppe.Core;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class CollectableManager : Singleton<CollectableManager>
    {
        private int coinCounter = 0;

        public void addCoin()
        {
            coinCounter += 1;
            Debug.Log("Moedas = " + coinCounter);
        }
    }
}
