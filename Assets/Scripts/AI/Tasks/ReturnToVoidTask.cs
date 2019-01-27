using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBase.Unity.Extensions;

namespace AI.Tasks
{
    class ReturnToVoidTask : IAITask
    {
        public void Initialize()
        {

        }

        public void OnAdd(AIBase AI)
        {
            if (AI.GameManager.Portals.Count > 0)
            {
                AI.Animator.SetBool("IsIdle", false);
                AI.Animator.SetBool("IsWalking", true);
                AI.Animator.SetBool("IsRunning", false);
                AI.NavAgent.SetDestination((AI.GameManager.Portals.GetClosestTo(AI.gameObject.transform.position).transform.position));
            }
            else
            {
                AI.CurrentTask = AIBase.IDLE;
            }
        }

        public void OnRemove(AIBase AI)
        {
        }

        public void Update(AIBase AI)
        {
        }
    }
}
