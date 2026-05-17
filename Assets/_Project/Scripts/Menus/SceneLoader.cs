using UnityEngine;
using UnityEngine.SceneManagement;

namespace TopDownSurvivors.Menus
{
    public sealed class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            if (!string.IsNullOrWhiteSpace(sceneName))
            {
                SceneManager.LoadScene(sceneName);
            }
        }

        public void ReloadCurrentScene()
        {
            Scene activeScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(activeScene.name);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
