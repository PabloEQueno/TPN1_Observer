namespace TopDownSurvivors.Progression
{
    public interface IXPCollector
    {
        int CurrentXP { get; }
        void AddXP(int amount);
    }
}
