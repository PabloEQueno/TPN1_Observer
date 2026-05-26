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

        public List<PowerSO> GetRandomChoices()
        {
            List<PowerSO> choices = new List<PowerSO>();
            if (availablePowers == null || availablePowers.Count == 0) return choices;

            List<PowerSO> poolCopy = new List<PowerSO>(availablePowers);

            int iterations = Mathf.Min(choicesPerLevelUp, poolCopy.Count);

            for (int i = 0; i < iterations; i++)
            {
                int randomIndex = Random.Range(0, poolCopy.Count);
                choices.Add(poolCopy[randomIndex]);
                poolCopy.RemoveAt(randomIndex); 
            }

            return choices;
        }
    }
}