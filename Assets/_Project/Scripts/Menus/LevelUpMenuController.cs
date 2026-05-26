using TopDownSurvivors.Core;
using TopDownSurvivors.Progression;
using TopDownSurvivors.UI;
using UnityEngine;
using System.Collections.Generic;

namespace TopDownSurvivors.Menus
{
    public sealed class LevelUpMenuController : MonoBehaviour
    {
        [SerializeField] private LevelUpUI levelUpUI;
        [SerializeField] private PowerChoiceManager choiceManager;
        [SerializeField] private PowerApplier powerApplier;
        [SerializeField] private TimeService timeService;
        [SerializeField] private GameManager gameManager;

        public void Open()
        {
            if (choiceManager != null && levelUpUI != null)
            {
                List<PowerSO> randomChoices = choiceManager.GetRandomChoices();
                levelUpUI.SetupChoices(randomChoices);
            }
            else if (levelUpUI != null)
            {
                levelUpUI.Show();
            }

            timeService?.Pause();
            gameManager?.SetState(GameState.LevelUp);
        }

        public void ChoosePower(PowerSO power)
        {
            if (power != null && powerApplier != null)
            {
                powerApplier.ApplyPower(power);
                Debug.Log($"[POWER UP SOLID] Se aplicó con éxito la mejora: {power.DisplayName}");
            }

            levelUpUI?.Hide();
            timeService?.Resume();
            gameManager?.SetState(GameState.Playing);
        }
    }
}