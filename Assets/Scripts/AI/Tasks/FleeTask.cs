using UnityEngine;
using WBase.Unity.Extensions;

namespace AI.Tasks
{
    public class FleeTask : IAITask
    {
        float LastDestTime = 0;

        public void Initialize()
        {

        }

        public void OnAdd(AIBase AI)
        {
            AI.Animator.SetBool("IsIdle", false);
            AI.Animator.SetBool("IsWalking", false);
            AI.Animator.SetBool("IsRunning", true);
            AI.NavAgent.speed = 10;
        }

        public void OnRemove(AIBase AI)
        {
            AI.NavAgent.speed = 5;
        }

        public void Update(AIBase AI)
        {
            if (!AI.NavAgent.hasPath || Time.time > LastDestTime + VillagerAI.FLEE_UPDATE_DELAY)
            {
                LastDestTime = Time.time;
                Vector3 Offset = (AI.GameManager.Demons.GetClosestTo(AI.transform.position).transform.position - AI.transform.position).normalized;
                AI.NavAgent.SetDestination(AI.transform.position + Offset);
            }
        }
    }
}