using UnityEngine;

namespace AI.Tasks
{
    [RequireComponent(typeof(Animation))]
    internal class IdleTask : IAITask
    {
        public void Initialize()
        {

        }

        public void OnAdd(VillagerAI AI)
        {
            AI.Animator.SetBool("IsIdle", true);
            AI.Animator.SetBool("IsWalking", false);
            AI.Animator.SetBool("IsRunning", false);
        }

        public void OnRemove(VillagerAI AI)
        {

        }

        public void Update(VillagerAI AI)
        {

        }
    }
}