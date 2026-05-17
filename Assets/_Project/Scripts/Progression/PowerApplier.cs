using TopDownSurvivors.Combat;
using UnityEngine;

namespace TopDownSurvivors.Progression
{
    public sealed class PowerApplier : MonoBehaviour
    {
        [SerializeField] private WeaponStats weaponStats;

        public WeaponStats WeaponStats => weaponStats;

        public void ApplyPower(PowerSO power)
        {
            power?.ApplyTo(weaponStats);
        }
    }
}
