using System;
using UnityEngine;

namespace AI.Tasks
{
    internal class ReturnHomeTask : IAITask
    {
        private Vector3 HomePos { get; set; }

        public void Initialize()
        {

        }

        public void OnAdd(VillagerAI AI)
        {
            AI.Animator.SetBool("IsIdle", false);
            AI.Animator.SetBool("IsWalking", true);
            AI.Animator.SetBool("IsRunning", false);
        }

        public void OnRemove(VillagerAI AI)
        {

        }

        public void Update(VillagerAI AI)
        {
            if (!AI.NavAgent.hasPath)
            {
                AI.NavAgent.SetDestination(HomePos);
            }
        }
    }
}