namespace TopDownSurvivors.Fear
{
    public interface IFearObserver
    {
        void OnFearChanged(FearContext context);
    }
}
