using UnityEngine;

namespace AI
{
    public interface IAITask
    {
        void Update(VillagerAI AI);

        void OnRemove(VillagerAI AI);

        void OnAdd(VillagerAI AI);

        void Initialize();
    }
}