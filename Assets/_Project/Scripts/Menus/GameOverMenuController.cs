using UnityEngine;

namespace TopDownSurvivors.Menus
{
    public sealed class GameOverMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private SceneLoader sceneLoader;
        [SerializeField] private string mainMenuSceneName = "MainMenu";

        public void Show()
        {
            gameOverPanel?.SetActive(true);
        }

        public void Restart()
        {
            sceneLoader?.ReloadCurrentScene();
        }

        public void ReturnToMainMenu()
        {
            sceneLoader?.LoadScene(mainMenuSceneName);
        }
    }
}
