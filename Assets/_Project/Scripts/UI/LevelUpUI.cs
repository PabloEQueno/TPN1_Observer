using System.Collections.Generic;
using TopDownSurvivors.Progression;
using UnityEngine;

namespace TopDownSurvivors.UI
{
    public sealed class LevelUpUI : MonoBehaviour
    {
        [SerializeField] private GameObject root;

        public void Show(IReadOnlyList<PowerSO> choices)
        {
            if (root != null)
            {
                root.SetActive(true);
            }
        }

        public void Hide()
        {
            if (root != null)
            {
                root.SetActive(false);
            }
        }
    }
}
