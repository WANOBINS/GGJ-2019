using System;
using AI.Tasks;
using UnityEngine;
using UnityEngine.AI;
using WBase.Unity.Extensions;
using WBase.Unity.Util;

namespace AI
{
    [RequireComponent(typeof(Animator))]
    public class VillagerAI : MonoBehaviour
    {
        public static readonly IAITask IDLE = new IdleTask();
        public static readonly IAITask WANDER = new WanderTask();
        public static readonly IAITask HOME = new ReturnHomeTask();
        public static readonly IAITask FLEE = new FleeTask();

        public double FleeDistance = 10;
        public const double FLEE_UPDATE_DELAY = 1;
        public const double WANDER_UPDATE_DELAY = 10;

        public Animator Animator { get; private set; }
        public NavMeshAgent NavAgent { get; private set; }
        public GameObject[] Enemies { get; private set; }
        public UnityEngine.Random RNG { get; private set; }

        private IAITask currentTask;
        public IAITask CurrentTask
        {
            get
            {
                return currentTask;
            }
            set
            {
                if (currentTask == value)
                {
                    ResetAnim();
                    return;
                }
                currentTask.OnRemove(this);
                currentTask = value;
                currentTask.OnAdd(this);
            }
        }

        public void Awake()
        {
            UnityEngine.Random.InitState(TimeUtil.UnixTimestamp);
            Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Animator = GetComponent<Animator>();
            NavAgent = transform.parent.GetComponent<NavMeshAgent>();
        }

        public void Start()
        {
            IDLE.Initialize();
            WANDER.Initialize();
            HOME.Initialize();
            FLEE.Initialize();
        }

        /// <summary>
        /// All AI decisions should be made here
        /// </summary>
        public void Update()
        {
            if ((Enemies.GetClosestTo(transform.position).transform.position - transform.position).magnitude < FleeDistance)
            {
                CurrentTask = FLEE;
            }
            if (CurrentTask == null)
                return;
            CurrentTask.Update(this);
        }

        public void ResetAnim()
        {
            Animator.SetBool("IsIdle", true);
            Animator.SetBool("IsWalking", false);
            Animator.SetBool("IsRunning", false);
        }
    }
}