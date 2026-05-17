using System.Collections.Generic;
using UnityEngine;

namespace TopDownSurvivors.Data
{
    [CreateAssetMenu(fileName = "FearProgression", menuName = "Top Down Survivors/Fear/Fear Progression")]
    public sealed class FearProgressionSO : ScriptableObject
    {
        [SerializeField, Min(1f)] private float secondsToReachMaximumFear = 300f;
        [SerializeField] private List<FearRangeSO> ranges = new();

        public float SecondsToReachMaximumFear => secondsToReachMaximumFear;
        public IReadOnlyList<FearRangeSO> Ranges => ranges;

        public FearRangeSO GetRange(int fearValue)
        {
            foreach (FearRangeSO range in ranges)
            {
                if (range != null && range.Contains(fearValue))
                {
                    return range;
                }
            }

            return null;
        }
    }
}
