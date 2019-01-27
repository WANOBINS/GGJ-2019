using AI.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using WBase.Unity.Util;

namespace AI
{
    public class AIBase : MonoBehaviour
    {
        public static readonly IAITask IDLE = new IdleTask();
        public static readonly IAITask WANDER = new WanderTask();

        public Animator Animator { get; protected set; }
        public NavMeshAgent NavAgent { get; protected set; }
        public GameManager GameManager { get; protected set; }

        public UnityEngine.Random RNG { get; private set; }

        protected IAITask currentTask = IDLE;
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

        public virtual void Awake()
        {
            UnityEngine.Random.InitState(TimeUtil.UnixTimestamp);
            GameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
            Animator = GetComponentInChildren<Animator>();
            NavAgent = GetComponent<NavMeshAgent>();
        }

        // Use this for initialization
        public virtual void Start()
        {
            IDLE.Initialize();
            WANDER.Initialize();
        }

        // Update is called once per frame
        public virtual void Update()
        {
            if (!NavAgent.hasPath && CurrentTask != IDLE)
            {
                CurrentTask = IDLE;
            }
        }

        public virtual void ResetAnim()
        {
            Animator.SetBool("IsIdle", true);
            Animator.SetBool("IsWalking", false);
            Animator.SetBool("IsRunning", false);
        }
    }
}
