using UnityEngine;

namespace TopDownSurvivors.Player
{
    public sealed class PlayerExperience : MonoBehaviour
    {
        [SerializeField, Min(0)] private int currentXP;
        [SerializeField] private PlayerLevel playerLevel;

        public int CurrentXP => currentXP;

        private void Awake()
        {
            if (playerLevel == null) playerLevel = GetComponent<PlayerLevel>();
        }

        public void AddXP(int amount)
        {
            currentXP += Mathf.Max(0, amount);

            if (playerLevel != null && currentXP >= playerLevel.XPRequiredForNextLevel)
            {
                currentXP -= playerLevel.XPRequiredForNextLevel; 
                playerLevel.LevelUp();
            }
        }
    }
}