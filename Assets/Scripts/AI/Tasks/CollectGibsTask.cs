using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBase.Unity.Extensions;
using Log = UnityEngine.Debug;

namespace AI.Tasks
{
    class CollectGibsTask : IAITask
    {
        public void Initialize()
        {

        }

        public void OnAdd(AIBase ai)
        {
            if (ai.GameManager.Gibs.Count > 0)
            {
                ai.NavAgent.SetDestination(ai.GameManager.Gibs.GetClosestTo(ai.transform.position).transform.position);
                Log.Log(ai.gameObject.name + " set destination to " + ai.NavAgent.destination);
                ai.Animator.SetBool("IsIdle", false);
                ai.Animator.SetBool("IsWalking", true);
                ai.Animator.SetBool("IsRunning", false);
            }
            else
            {
                ai.CurrentTask = AIBase.IDLE;
            }
        }

        public void OnRemove(AIBase ai)
        {

        }

        public void Update(AIBase ai)
        {
            if (((DemonAI)ai).GibCount > 0)
            {
                //ai.Animator.Play("HasGib");
                //TODO: Add to Player's Gib count or power
                ((DemonAI)ai).GibCount = 0;
            }
            if (!ai.NavAgent.hasPath)
            {
                ai.ResetAnim();
            }
        }
    }
}
