using UnityEngine;

namespace TopDownSurvivors.Core
{
    public sealed class TimeService : MonoBehaviour, ITimeService
    {
        public float DeltaTime => Time.deltaTime;

        public float TimeScale
        {
            get => Time.timeScale;
            set => Time.timeScale = value;
        }

        public void Pause()
        {
            TimeScale = 0f;
        }

        public void Resume()
        {
            TimeScale = 1f;
        }
    }
}
