using AI.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    [RequireComponent(typeof(NavMeshAgent))]
    internal class VillagerAI : MonoBehaviour
    {
        public static readonly IAITask IDLE = new IdleTask();
        public static readonly IAITask WANDER = new WanderTask();
        public static readonly IAITask HOME = new ReturnHomeTask();

        private IAITask currentTask;

        public IAITask CurrentTask
        {
            get
            {
                return currentTask;
            }
            set
            {
                currentTask.OnRemove(gameObject);
                currentTask = value;
                currentTask.OnAdd(gameObject);
            }
        }

        public void Start()
        {
            IDLE.Initialize();
        }

        public void Update()
        {
            if (CurrentTask == null)
                return;
            CurrentTask.Update(gameObject);
        }
    }
}