using UnityEngine;

namespace AI.Tasks
{
    public class FleeTask : IAITask
    {
        float LastDestTime = 0;

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
        }

        public void Update(VillagerAI AI)
        {
            if (!AI.NavAgent.hasPath || Time.time > LastDestTime + VillagerAI.FLEE_UPDATE_DELAY)
            {
                LastDestTime = Time.time;
                Vector3 Offset = (AI.Player.transform.position - AI.transform.position).normalized;
                AI.NavAgent.SetDestination(AI.transform.position + Offset);
            }
        }
    }
}