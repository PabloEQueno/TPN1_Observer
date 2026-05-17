using TopDownSurvivors.Combat;

namespace TopDownSurvivors.Progression
{
    public interface IPowerEffect
    {
        void ApplyTo(WeaponStats weaponStats);
    }
}
