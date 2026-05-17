using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TopDownSurvivors.UI
{
    public sealed class HealthView : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;
        [SerializeField] private TMP_Text healthText;

        public void SetHealth(float currentHealth, float maxHealth)
        {
            if (healthSlider != null)
            {
                healthSlider.value = maxHealth > 0f ? currentHealth / maxHealth : 0f;
            }

            if (healthText != null)
            {
                healthText.text = $"{currentHealth:0}/{maxHealth:0}";
            }
        }
    }
}
