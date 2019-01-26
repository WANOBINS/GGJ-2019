using UnityEngine;

namespace AI.Tasks
{
    [RequireComponent(typeof(Animation))]
    internal class IdleTask : IAITask
    {
        public static AnimationClip IdleAnim { get; private set; }

        private Animation Animation;

        public void Initialize()
        {
            IdleAnim = Resources.Load<AnimationClip>("Animations/Idle");
        }

        public void OnAdd(GameObject gameObject)
        {
            Animation = gameObject.GetComponent<Animation>();
            Animation.AddClip(IdleAnim, "Idle");
            Animation.Play();
        }

        public void OnRemove(GameObject gameObject)
        {
            Animation.Stop();
            Animation.RemoveClip(IdleAnim);
            Animation = null;
        }

        public void Update(GameObject gameObject)
        {
        }
    }
}