using TopDownSurvivors.Data;

namespace TopDownSurvivors.Fear
{
    public readonly struct FearContext
    {
        public FearContext(float elapsedSeconds, int fearValue, FearRangeSO currentRange)
        {
            ElapsedSeconds = elapsedSeconds;
            FearValue = fearValue;
            CurrentRange = currentRange;
        }

        public float ElapsedSeconds { get; }
        public int FearValue { get; }
        public FearRangeSO CurrentRange { get; }
    }
}
