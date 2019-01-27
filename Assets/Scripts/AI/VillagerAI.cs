using System;
using AI.Tasks;
using UnityEngine;
using UnityEngine.AI;
using WBase.Unity.Extensions;
using WBase.Unity.Util;

namespace AI
{
    public class VillagerAI : AIBase
    {


        public static readonly IAITask HOME = new ReturnHomeTask();
        public static readonly IAITask FLEE = new FleeTask();

        public double FleeDistance = 10;
        public const double FLEE_UPDATE_DELAY = 1;

        public override void Awake()
        {
            base.Awake();

        }

        public override void Start()
        {
            base.Start();
            HOME.Initialize();
            FLEE.Initialize();
        }

        /// <summary>
        /// All AI decisions should be made here
        /// </summary>
        public override void Update()
        {
            base.Update();
            if(!NavAgent.hasPath || CurrentTask == IDLE)
            {
                CurrentTask = WANDER;
            }
            if (GameManager.Enemies.Count > 0 && (GameManager.Enemies.GetClosestTo(transform.position).transform.position - transform.position).magnitude < FleeDistance)
            {
                CurrentTask = FLEE;
            }
        }

        public override void ResetAnim()
        {
            base.ResetAnim();
        }
    }
}