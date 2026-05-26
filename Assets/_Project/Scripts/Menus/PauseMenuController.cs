using TopDownSurvivors.Core;
using UnityEngine;

namespace TopDownSurvivors.Menus
{
    public sealed class PauseMenuController : MonoBehaviour
    {
        [Header("UI Panels")]
        [SerializeField] private GameObject pausePanel;

        [Header("Services")]
        [SerializeField] private SceneLoader sceneLoader;
        [SerializeField] private TimeService timeService;

        [Header("Settings")]
        [SerializeField] private string mainMenuSceneName = "MainMenu";

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            {
                TogglePause();
            }
        }

        private void TogglePause()
        {
            var gameManager = GameManager.Instance;
            if (gameManager == null) return;

            if (gameManager.CurrentState == GameState.GameOver || 
                gameManager.CurrentState == GameState.LevelUp) 
            {
                return; 
            }

            if (gameManager.CurrentState == GameState.Paused) Resume();
            else if (gameManager.CurrentState == GameState.Playing) Pause();
        }

        public void Pause()
        {
            pausePanel?.SetActive(true);
            timeService?.Pause();
            GameManager.Instance?.SetState(GameState.Paused);
        }

        public void Resume()
        {
            pausePanel?.SetActive(false);
            timeService?.Resume();
            GameManager.Instance?.SetState(GameState.Playing);
        }

        public void Restart()
        {
            timeService?.Resume();
            GameManager.Instance?.SetState(GameState.Playing);
            sceneLoader?.ReloadCurrentScene();
        }

        public void ReturnToMainMenu()
        {
            timeService?.Resume();
            sceneLoader?.LoadScene(mainMenuSceneName);
        }

        public void Quit() => sceneLoader?.QuitGame();
    }
}