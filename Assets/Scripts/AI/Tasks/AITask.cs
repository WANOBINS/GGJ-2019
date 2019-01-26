using UnityEngine;

namespace AI
{
    public interface IAITask
    {
        void Update(VillagerAI ai);

        void OnRemove(VillagerAI ai);

        void OnAdd(VillagerAI ai);

        void Initialize();
    }
}