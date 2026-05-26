using UnityEngine;
using TopDownSurvivors.Core;

namespace TopDownSurvivors.Core
{
    public sealed class SceneBootstrapper : MonoBehaviour
    {
        [SerializeField] private GameState startupState = GameState.Playing;

        private void Start()
        { 
            GameManager manager = FindFirstObjectByType<GameManager>();
            
            if (manager != null)
            {
                manager.SetState(startupState);
            }
            else
            {
                Debug.LogWarning("[Bootstrapper] No se encontró un GameManager en esta escena.");
            }
        }
    }
}