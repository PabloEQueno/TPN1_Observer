using UnityEngine;

public class GlobalServicesInitializer : MonoBehaviour
{
    [SerializeField] private GameObject audioManagerPrefab;
    [SerializeField] private GameObject gameManagerPrefab;

    private void Awake()
    {
        if (audioManagerPrefab != null)
        {
            var audio = Instantiate(audioManagerPrefab);
            DontDestroyOnLoad(audio);
        }
        
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}