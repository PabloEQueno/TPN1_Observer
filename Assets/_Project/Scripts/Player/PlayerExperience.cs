using TopDownSurvivors.Progression;
using UnityEngine;

namespace TopDownSurvivors.Player
{
    public sealed class PlayerExperience : MonoBehaviour, IXPCollector
    {
        [SerializeField, Min(0)] private int currentXP;

        public int CurrentXP => currentXP;

        public void AddXP(int amount)
        {
            currentXP += Mathf.Max(0, amount);
        }
    }
}
