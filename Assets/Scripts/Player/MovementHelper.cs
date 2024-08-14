﻿using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.Player
{
    public class MovementHelper : MonoBehaviour
    {
        [Header("Lerp Settings")]
        public float lerpTime;
        public Transform target;

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, target.position, lerpTime * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                StopPlayer(0f);
            }

            if (collision.gameObject.CompareTag("Finish"))
            {
                StopPlayer(2f);
            }
        }

        private void StopPlayer(float stopTime)
        {
            DOTween.To(() => lerpTime, x => lerpTime = x, 0f, stopTime);
        }
    }
}