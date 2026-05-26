using System;
using UnityEngine;

namespace TopDownSurvivors.Core
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private GameState initialState = GameState.Playing;

        public GameState CurrentState { get; private set; }

        public static event Action<GameState> OnStateChanged;

        private void Awake()
        {
            CurrentState = initialState;
        }

        private void Start()
        {
            OnStateChanged?.Invoke(CurrentState);
        }

        public void SetState(GameState nextState)
        {
            if (CurrentState == nextState) return; 

            CurrentState = nextState;
            
            OnStateChanged?.Invoke(CurrentState);
        }
    }
}