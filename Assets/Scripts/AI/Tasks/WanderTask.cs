using System;
using System.Collections;
using UnityEngine;

namespace AI.Tasks
{
    internal class WanderTask : IAITask
    {
        public VillagerAI AI { get; private set; }
        public double LastDestTime { get; private set; }

        public void Initialize()
        {

        }

        public void OnAdd(VillagerAI AI)
        {
            this.AI = AI;
            AI.Animator.SetBool("IsIdle", false);
            AI.Animator.SetBool("IsWalking", true);
            AI.Animator.SetBool("IsRunning", false);
        }

        public void OnRemove(VillagerAI AI)
        {
            this.AI = null;
        }

        public void Update(VillagerAI AI)
        {
            if (!AI.NavAgent.hasPath || Time.time > LastDestTime + VillagerAI.WANDER_UPDATE_DELAY)
            {
                LastDestTime = Time.time;
                AI.NavAgent.SetDestination(new Vector3());
            }
        }
    }
}