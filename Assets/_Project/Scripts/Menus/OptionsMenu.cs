using UnityEngine;
using UnityEngine.UI;
using TopDownSurvivors.Audio;

namespace TopDownSurvivors.Menus
{
    public sealed class OptionsMenu : MonoBehaviour
    {
        [Header("UI Sliders")]
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider sfxSlider;
        [SerializeField] private Slider uiSlider;

        private void OnEnable()
        {
            if (AudioManager.Instance != null)
            {
                musicSlider.value = AudioManager.Instance.GetMusicVolume();
                sfxSlider.value = AudioManager.Instance.GetSFXVolume();
                uiSlider.value = AudioManager.Instance.GetUIVolume();
            }

            musicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
            sfxSlider.onValueChanged.AddListener(OnSfxVolumeChanged);
            uiSlider.onValueChanged.AddListener(OnUiVolumeChanged);
        }

        private void OnDisable()
        {
            musicSlider.onValueChanged.RemoveListener(OnMusicVolumeChanged);
            sfxSlider.onValueChanged.RemoveListener(OnSfxVolumeChanged);
            uiSlider.onValueChanged.RemoveListener(OnUiVolumeChanged);
        }

        private void OnMusicVolumeChanged(float value)
        {
            AudioManager.Instance?.SetMusicVolume(value);
        }

        private void OnSfxVolumeChanged(float value)
        {
            AudioManager.Instance?.SetSFXVolume(value);
        }

        private void OnUiVolumeChanged(float value)
        {
            AudioManager.Instance?.SetUIVolume(value);
            
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayUISound(AudioManager.Instance.ButtonClickClip);
            }
        }
    }
}