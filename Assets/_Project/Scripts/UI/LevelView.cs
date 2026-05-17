using TMPro;
using UnityEngine;

namespace TopDownSurvivors.UI
{
    public sealed class LevelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text levelText;

        public void SetLevel(int level)
        {
            if (levelText != null)
            {
                levelText.text = $"Nivel {level}";
            }
        }
    }
}
