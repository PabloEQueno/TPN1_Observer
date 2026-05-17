using TopDownSurvivors.Core;
using UnityEngine;

namespace TopDownSurvivors.Menus
{
    public sealed class PauseMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject pausePanel;
        [SerializeField] private SceneLoader sceneLoader;
        [SerializeField] private TimeService timeService;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private string mainMenuSceneName = "MainMenu";

        public void Pause()
        {
            pausePanel?.SetActive(true);
            timeService?.Pause();
            gameManager?.SetState(GameState.Paused);
        }

        public void Resume()
        {
            pausePanel?.SetActive(false);
            timeService?.Resume();
            gameManager?.SetState(GameState.Playing);
        }

        public void Restart()
        {
            timeService?.Resume();
            sceneLoader?.ReloadCurrentScene();
        }

        public void ReturnToMainMenu()
        {
            timeService?.Resume();
            sceneLoader?.LoadScene(mainMenuSceneName);
        }

        public void Quit()
        {
            sceneLoader?.QuitGame();
        }
    }
}
