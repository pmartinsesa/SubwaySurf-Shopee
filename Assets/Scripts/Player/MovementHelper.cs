﻿using Assets.Scripts.SubwaySurfShoppe.Core;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Player
{
    public class MovementHelper : Singleton<MovementHelper>
    {
        [Header("Lerp Settings")]
        public float lerpTime;
        public Transform target;

        private bool _isInvencible = false;

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, target.position, lerpTime * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                if (_isInvencible) return; 

                StopPlayer(0f);
                Invoke(nameof(EndGame), 2f);
            }

            if (collision.gameObject.CompareTag("Finish"))
            {
                StopPlayer(2f);
                Invoke(nameof(EndGame), 2f);
            }
        }

        private void StopPlayer(float stopTime)
        {
            DOTween.To(() => lerpTime, x => lerpTime = x, 0f, stopTime);
        }

        private void EndGame()
        {
            SceneManager.LoadScene(0);
        }

        public void ChangeStateIsInvencible()
        {
            _isInvencible = !_isInvencible;
        }
    }
}