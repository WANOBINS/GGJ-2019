using System;
using AI.Tasks;
using UnityEngine;
using UnityEngine.AI;
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

        public const double FLEE_DIST = 10;
        public const double FLEE_UPDATE_DELAY = 1;
        public const double WANDER_UPDATE_DELAY = 10;

        public Animator Animator { get; private set; }
        public NavMeshAgent NavAgent { get; private set; }
        public GameObject Player { get; private set; }
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
            Player = GameObject.FindGameObjectWithTag("Player");
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
            if ((Player.transform.position - transform.position).magnitude < FLEE_DIST)
            {
                CurrentTask = FLEE;
            }
            if (CurrentTask == null)
                return;
            CurrentTask.Update(this);
        }

        public void ResetAnim()
        {
            Animator.SetBool("IsIdle", false);
            Animator.SetBool("IsWalking", false);
            Animator.SetBool("IsRunning", false);
        }
    }
}