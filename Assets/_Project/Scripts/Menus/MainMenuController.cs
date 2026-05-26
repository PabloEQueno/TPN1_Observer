using UnityEngine;
using UnityEngine.SceneManagement;
using TopDownSurvivors.Audio;
using TopDownSurvivors.Core;

namespace TopDownSurvivors.Menus
{
    public sealed class MainMenuController : MonoBehaviour
    {
        [SerializeField] private SceneLoader sceneLoader;
        [SerializeField] private string gameSceneName = "Game";
        [SerializeField] private GameObject optionsPanel;

        public void Play()
        {
            Time.timeScale = 1f;
            
			if (GameManager.Instance != null)
            {
                GameManager.Instance.SetState(GameState.Playing);
            }

            if (sceneLoader != null)
            {
                sceneLoader.LoadScene(gameSceneName);
            }
            else
            {
                SceneManager.LoadScene(gameSceneName);
            }
        }

        public void OpenOptions()
        {
            if (optionsPanel != null)
            {
                optionsPanel.SetActive(true);
            }
        }

        public void CloseOptions()
        {
            if (optionsPanel != null)
            {
                optionsPanel.SetActive(false);
            }
        }

        public void Quit()
        {
            sceneLoader?.QuitGame();
        }
    }
}