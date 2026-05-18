using UnityEngine;
using TopDownSurvivors.Menus;

namespace TopDownSurvivors.Player
{
    public sealed class PlayerLevel : MonoBehaviour
    {
        [SerializeField, Min(1)] private int currentLevel = 1;
        [SerializeField, Min(1)] private int xpRequiredForNextLevel = 10;
        [SerializeField] private LevelUpMenuController levelUpMenuController;

        public int CurrentLevel => currentLevel;
        public int XPRequiredForNextLevel => xpRequiredForNextLevel;

        private void Awake()
        {
            if (levelUpMenuController == null)
            {
                levelUpMenuController = FindFirstObjectByType<LevelUpMenuController>();
            }
        }

        public void LevelUp()
        {
            currentLevel++;
            
            xpRequiredForNextLevel = Mathf.RoundToInt(xpRequiredForNextLevel * 1.5f);

            if (levelUpMenuController != null)
            {
                levelUpMenuController.Open();
            }
        }
    }
}