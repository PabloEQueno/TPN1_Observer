using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TopDownSurvivors.Progression;
using TopDownSurvivors.Menus;

namespace TopDownSurvivors.UI
{
    public sealed class LevelUpUI : MonoBehaviour
    {
        [SerializeField] private GameObject root;
        [SerializeField] private LevelUpMenuController menuController;

        [Header("Ranuras Físicas de las Tarjetas (Mínimo 3)")]
        [SerializeField] private List<Button> choiceButtons = new();
        [SerializeField] private List<TMP_Text> titleTexts = new();
        [SerializeField] private List<TMP_Text> descriptionTexts = new();
        [SerializeField] private List<Image> iconImages = new();

        public void Show()
        {
            if (root != null) root.SetActive(true);
        }

        public void Hide()
        {
            if (root != null) root.SetActive(false);
        }

        public void SetupChoices(IReadOnlyList<PowerSO> choices)
        {
            Show();

            for (int i = 0; i < choiceButtons.Count; i++)
            {
                if (i >= choices.Count || choices[i] == null)
                {
                    if (choiceButtons[i] != null) choiceButtons[i].gameObject.SetActive(false);
                    continue;
                }

                choiceButtons[i].gameObject.SetActive(true);
                PowerSO power = choices[i];

                if (i < titleTexts.Count && titleTexts[i] != null) titleTexts[i].text = power.DisplayName;
                if (i < descriptionTexts.Count && descriptionTexts[i] != null) descriptionTexts[i].text = power.Description;
                if (i < iconImages.Count && iconImages[i] != null && power.Icon != null) iconImages[i].sprite = power.Icon;

                choiceButtons[i].onClick.RemoveAllListeners();

                PowerSO selectedPower = power;
                choiceButtons[i].onClick.AddListener(() => OnPowerSelected(selectedPower));
            }
        }

        private void OnPowerSelected(PowerSO power)
        {
            Hide();
            if (menuController != null)
            {
                menuController.ChoosePower(power);
            }
        }
    }
}