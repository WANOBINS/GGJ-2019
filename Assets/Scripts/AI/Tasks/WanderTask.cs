using System;
using System.Collections;
using UnityEngine;
using Log = UnityEngine.Debug;

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
            AI.NavAgent.speed = 5;
        }

        public void OnRemove(AIBase AI)
        {
            this.AI = null;
        }

        public void Update(AIBase AI)
        {
            if (AI.NavAgent.hasPath)
            {
                AI.Animator.SetBool("IsIdle", false);
                AI.Animator.SetBool("IsWalking", true);
                AI.Animator.SetBool("IsRunning", false);
            }
            else
            {
                AI.Animator.SetBool("IsIdle", true);
                AI.Animator.SetBool("IsWalking", false);
                AI.Animator.SetBool("IsRunning", false);
            }

            if (!AI.NavAgent.hasPath || Time.time > LastDestTime + AIBase.WANDER_UPDATE_DELAY)
            {
                LastDestTime = Time.time;
                AI.NavAgent.SetDestination(new Vector3((float)RandomRange(AIBase.WANDER_LOW_BOUND.x,AIBase.WANDER_HIGH_BOUND.x),0,(float)RandomRange(AIBase.WANDER_LOW_BOUND.y,AIBase.WANDER_HIGH_BOUND.y)));
                Log.Log(AI.gameObject.name + " destination set to " + AI.NavAgent.destination);
            }
        }

        private double RandomRange(double min, double max)
        {
            return min + (max - min) * AIBase.RNG.NextDouble();
        }
    }
}