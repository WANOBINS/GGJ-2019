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

        public void OnAdd(AIBase AI)
        {
            AI.Animator.SetBool("IsIdle", false);
            AI.Animator.SetBool("IsWalking", true);
            AI.Animator.SetBool("IsRunning", false);
            AI.NavAgent.speed = 5;
        }

        public void OnRemove(AIBase AI)
        {

        }

        public void Update(AIBase AI)
        {
            if (!AI.NavAgent.hasPath)
            {
                AI.NavAgent.SetDestination(HomePos);
            }
        }
    }
}