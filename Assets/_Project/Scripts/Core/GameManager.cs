using System;
using UnityEngine;

namespace TopDownSurvivors.Core
{
    public sealed class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField] private GameState initialState = GameState.MainMenu;

        public GameState CurrentState { get; private set; }

        public static event Action<GameState> OnStateChanged;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;     
            CurrentState = initialState;

            if (transform.parent != null)
            {
                DontDestroyOnLoad(transform.root.gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
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