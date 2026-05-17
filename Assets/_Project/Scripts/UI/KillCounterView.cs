using TMPro;
using UnityEngine;

namespace TopDownSurvivors.UI
{
    public sealed class KillCounterView : MonoBehaviour
    {
        [SerializeField] private TMP_Text killText;

        public void SetKills(int kills)
        {
            if (killText != null)
            {
                killText.text = kills.ToString();
            }
        }
    }
}
