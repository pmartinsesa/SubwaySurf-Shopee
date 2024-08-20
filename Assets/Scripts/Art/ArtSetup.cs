using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Art
{
    public class ArtSetup : MonoBehaviour
    {
        public void SetPieceArt(ArtSetupSO artSetup)
        {
            gameObject.GetComponentInParent<Renderer>().sharedMaterial.SetColor("_Color", artSetup.groundColor);   
            InstantiateArt(gameObject.GetComponentsInChildren<Transform>().ToList(), artSetup);
        }

        private void InstantiateArt(List<Transform> transforms, ArtSetupSO artSetup)
        {
            for (int i = 1; i < transforms.Count; i++)
            {
                var art = artSetup.art[Random.Range(0, artSetup.art.Count - 1)];
                art.GetComponent<Renderer>().sharedMaterial.SetColor("_Color", artSetup.objectColor);
                Instantiate(art, transforms[i]);
            }
        }
    }
}
