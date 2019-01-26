using System;
using AI.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    [RequireComponent(typeof(Animator))]
    public class VillagerAI : MonoBehaviour
    {
        public static readonly IAITask IDLE = new IdleTask();
        public static readonly IAITask WANDER = new WanderTask();
        public static readonly IAITask HOME = new ReturnHomeTask();
        public static readonly IAITask FLEE = new FleeTask();

        public Animator Animator { get; private set; }

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
                    return;
                currentTask.OnRemove(this);
                currentTask = value;
                currentTask.OnAdd(this);
            }
        }

        public void Start()
        {
            Animator = GetComponent<Animator>();
            IDLE.Initialize();
            WANDER.Initialize();
            HOME.Initialize();
        }

        public void Update()
        {
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