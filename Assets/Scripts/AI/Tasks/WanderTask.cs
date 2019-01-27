using System;
using System.Collections;
using UnityEngine;

namespace AI.Tasks
{
    internal class WanderTask : IAITask
    {
        public AIBase AI { get; private set; }
        public double LastDestTime { get; private set; }

        public void Initialize()
        {

        }

        public void OnAdd(AIBase AI)
        {
            this.AI = AI;
            AI.Animator.SetBool("IsIdle", false);
            AI.Animator.SetBool("IsWalking", true);
            AI.Animator.SetBool("IsRunning", false);
            AI.NavAgent.speed = 5;
        }

        public void OnRemove(AIBase AI)
        {
            this.AI = null;
        }

        public void Update(AIBase AI)
        {
            if (!AI.NavAgent.hasPath || Time.time > LastDestTime + VillagerAI.WANDER_UPDATE_DELAY)
            {
                LastDestTime = Time.time;
                AI.NavAgent.SetDestination(new Vector3());
            }
        }
    }
}