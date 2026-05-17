using UnityEngine;

namespace TopDownSurvivors.Core
{
    public sealed class SceneBootstrapper : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private GameState startupState = GameState.Playing;

        private void Start()
        {
            if (gameManager != null)
            {
                gameManager.SetState(startupState);
            }
        }
    }
}
