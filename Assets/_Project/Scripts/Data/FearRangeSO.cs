using UnityEngine;

namespace TopDownSurvivors.Data
{
    [CreateAssetMenu(fileName = "FearRange", menuName = "Top Down Survivors/Fear/Fear Range")]
    public sealed class FearRangeSO : ScriptableObject
    {
        [SerializeField] private string rangeName;
        [SerializeField, Range(0, 100)] private int minimumFearValue;
        [SerializeField, Range(0, 100)] private int maximumFearValue = 25;
        [SerializeField] private Color uiColor = Color.white;

        public string RangeName => rangeName;
        public int MinimumFearValue => minimumFearValue;
        public int MaximumFearValue => maximumFearValue;
        public Color UIColor => uiColor;

        public bool Contains(int fearValue)
        {
            return fearValue >= minimumFearValue && fearValue <= maximumFearValue;
        }
    }
}
