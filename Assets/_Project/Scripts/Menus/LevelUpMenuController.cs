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
            GameManager.Instance?.SetState(GameState.LevelUp);
        }

        public void ChoosePower(PowerSO power)
        {
            if (power != null && powerApplier != null)
            {
                powerApplier.ApplyPower(power);
            }

            levelUpUI?.Hide();
            timeService?.Resume();
            GameManager.Instance?.SetState(GameState.Playing);
        }
    }
}