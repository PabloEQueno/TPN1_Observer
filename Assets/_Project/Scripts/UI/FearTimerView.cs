using TMPro;
using UnityEngine;

namespace TopDownSurvivors.UI
{
    public sealed class FearTimerView : MonoBehaviour
    {
        [SerializeField] private TMP_Text timerText;

        public void SetTime(float elapsedSeconds)
        {
            int minutes = Mathf.FloorToInt(elapsedSeconds / 60f);
            int seconds = Mathf.FloorToInt(elapsedSeconds % 60f);

            if (timerText != null)
            {
                timerText.text = $"{minutes:00}:{seconds:00}";
            }
        }
    }
}
