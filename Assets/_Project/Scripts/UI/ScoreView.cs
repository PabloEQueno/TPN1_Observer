using TMPro;
using UnityEngine;

namespace TopDownSurvivors.UI
{
    public sealed class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;

        public void SetScore(int score)
        {
            if (scoreText != null)
            {
                scoreText.text = score.ToString();
            }
        }
    }
}
