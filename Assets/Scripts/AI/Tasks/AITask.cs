using UnityEngine;

namespace AI
{
    public interface IAITask
    {
        void Update(AIBase ai);

        void OnRemove(AIBase ai);

        void OnAdd(AIBase ai);

        void Initialize();
    }
}