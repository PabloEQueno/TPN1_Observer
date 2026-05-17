using System.Collections.Generic;
using UnityEngine;

namespace TopDownSurvivors.Progression
{
    public sealed class PowerChoiceManager : MonoBehaviour
    {
        [SerializeField] private List<PowerSO> availablePowers = new();
        [SerializeField, Min(1)] private int choicesPerLevelUp = 3;
        [SerializeField] private PowerApplier powerApplier;

        public IReadOnlyList<PowerSO> AvailablePowers => availablePowers;
        public int ChoicesPerLevelUp => choicesPerLevelUp;
        public PowerApplier PowerApplier => powerApplier;
    }
}
