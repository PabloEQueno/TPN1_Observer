namespace TopDownSurvivors.Core
{
    public interface ITimeService
    {
        float DeltaTime { get; }
        float TimeScale { get; set; }
        void Pause();
        void Resume();
    }
}
