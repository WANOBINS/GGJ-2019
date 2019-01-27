using AI;
using AI.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using WBase.Unity.Util;

namespace AI {
    public class DemonAI : AIBase
    {
        public static readonly IAITask COLLECT_GIBS = new CollectGibsTask();
        public static readonly IAITask RETURN_TO_VOID = new ReturnToVoidTask();

        public const int MINIMUM_HAPPINESS = 10; 

        public int GibCount = 0;
        public int Happiness { get; internal set; } = 10;

        private void Start()
        {
            if (!GameManager.Demons.Contains(gameObject))
            {
                GameManager.Demons.Add(gameObject);
            }
        }

        public override void Update()
        {
            base.Update();
            if (Happiness < MINIMUM_HAPPINESS)
            {
                CurrentTask = RETURN_TO_VOID;
            }
            else if (GameManager.Gibs.Count > 0)
            {
                CurrentTask = COLLECT_GIBS;
            }
            else
            {
                CurrentTask = WANDER;
            }
        }

        private void OnDestroy()
        {
            if (GameManager.Demons.Contains(gameObject))
            {
                GameManager.Demons.Remove(gameObject);
            }
        }
    }
}
