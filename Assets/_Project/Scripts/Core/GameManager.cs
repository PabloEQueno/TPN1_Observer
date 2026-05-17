using UnityEngine;

namespace TopDownSurvivors.Core
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private GameState initialState = GameState.Playing;

        public GameState CurrentState { get; private set; }

        private void Awake()
        {
            CurrentState = initialState;
        }

        public void SetState(GameState nextState)
        {
            CurrentState = nextState;
        }
    }
}
