using TMPro;
using TopDownSurvivors.Data;
using UnityEngine;
using UnityEngine.UI;

namespace TopDownSurvivors.UI
{
    public sealed class FearLevelView : MonoBehaviour
    {
        [SerializeField] private Slider fearSlider;
        [SerializeField] private TMP_Text fearText;
        [SerializeField] private Image fillImage;

        public void SetFear(int fearValue, FearRangeSO range)
        {
            if (fearSlider != null)
            {
                fearSlider.value = fearValue / 100f;
            }

            if (fearText != null)
            {
                fearText.text = range != null ? $"{range.RangeName} {fearValue}" : fearValue.ToString();
            }

            if (fillImage != null && range != null)
            {
                fillImage.color = range.UIColor;
            }
        }
    }
}
