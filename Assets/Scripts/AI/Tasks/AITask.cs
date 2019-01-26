using UnityEngine;

namespace AI
{
    public interface IAITask
    {
        void Update(GameObject gameObject);

        void OnRemove(GameObject gameObject);

        void OnAdd(GameObject gameObject);

        void Initialize();
    }
}