using UnityEngine;

namespace Assets.Scripts.Player
{
    public class AnimationHelper : MonoBehaviour
    {
        [Header("Animator Settings")]
        public Animator animator;
        public string runTrigger;
        public string deadTrigger;
        public string idleTrigger;

        [Header("Animation Settings")]
        public Animation running;

        public void onRun()
        {
            animator.SetTrigger(runTrigger);
        }

        public void onIdle()
        {
            animator.ResetTrigger(runTrigger);
            animator.SetTrigger(idleTrigger);
        }

        public void onDead()
        {
            animator.ResetTrigger(runTrigger);
            animator.SetTrigger(deadTrigger);
        }
    }
}
