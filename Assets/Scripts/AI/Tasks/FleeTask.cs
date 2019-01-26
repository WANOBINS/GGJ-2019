using UnityEngine;

namespace AI.Tasks
{
    public class FleeTask : IAITask
    {
        public void Initialize()
        {

        }

        public void OnAdd(VillagerAI AI)
        {
            AI.Animator.SetBool("IsIdle", false);
            AI.Animator.SetBool("IsWalking", false);
            AI.Animator.SetBool("IsRunning", true);
        }

        public void OnRemove(VillagerAI AI)
        {
            AI.ResetAnim();
        }

        public void Update(VillagerAI AI)
        {
        }
    }
}