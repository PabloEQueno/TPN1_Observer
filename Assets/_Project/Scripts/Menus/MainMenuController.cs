using UnityEngine;

namespace TopDownSurvivors.Menus
{
    public sealed class MainMenuController : MonoBehaviour
    {
        [SerializeField] private SceneLoader sceneLoader;
        [SerializeField] private string gameSceneName = "Game";
        [SerializeField] private GameObject optionsPanel;

       
        public void Play()
        {
            sceneLoader?.LoadScene(gameSceneName);
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
