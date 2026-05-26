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
                // Reestablecemos el tiempo a la normalidad antes de cambiar de escena
                Time.timeScale = 1f;
                SceneManager.LoadScene(sceneName);
            }
        }

        public void ReloadCurrentScene()
        {
            // Reestablecemos el tiempo a la normalidad antes de reiniciar la escena
            Time.timeScale = 1f;
            
            Scene activeScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(activeScene.name);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
