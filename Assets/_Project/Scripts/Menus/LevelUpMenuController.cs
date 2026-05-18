using TopDownSurvivors.Core;
using TopDownSurvivors.Progression;
using TopDownSurvivors.UI;
using UnityEngine;

namespace TopDownSurvivors.Menus
{
    public sealed class LevelUpMenuController : MonoBehaviour
    {
        [SerializeField] private LevelUpUI levelUpUI;
        [SerializeField] private PowerApplier powerApplier;
        [SerializeField] private TimeService timeService;
        [SerializeField] private GameManager gameManager;

        public void Open()
        {
            timeService?.Pause();
            gameManager?.SetState(GameState.LevelUp);
            
                if (levelUpUI != null)
            {
                levelUpUI.Show();
            }
        }

        public void ChoosePower(PowerSO power)
        {
            
            levelUpUI?.Hide();
            timeService?.Resume();
            gameManager?.SetState(GameState.Playing);
        }
    }
}