using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TopDownSurvivors.UI
{
    public sealed class XPBarView : MonoBehaviour
    {
        [SerializeField] private Slider xpSlider;
        [SerializeField] private TMP_Text xpText;

        public void UpdateXP(int currentXP, int requiredXP)
        {
            if (xpSlider != null)
            {
                xpSlider.maxValue = requiredXP;
                xpSlider.value = currentXP;
            }

            if (xpText != null)
            {
                xpText.text = $"XP: {currentXP} / {requiredXP}";
            }
        }
    }
}