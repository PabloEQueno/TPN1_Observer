using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TopDownSurvivors.UI
{
    public sealed class XPBarView : MonoBehaviour
    {
        [SerializeField] private Slider xpSlider;
        [SerializeField] private TMP_Text xpText;

        public void SetXP(int currentXP, int requiredXP)
        {
            if (xpSlider != null)
            {
                xpSlider.value = requiredXP > 0 ? (float)currentXP / requiredXP : 0f;
            }

            if (xpText != null)
            {
                xpText.text = $"{currentXP}/{requiredXP}";
            }
        }
    }
}
