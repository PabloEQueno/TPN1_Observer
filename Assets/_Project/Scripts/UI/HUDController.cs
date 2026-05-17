using UnityEngine;
using TopDownSurvivors.Fear;
using TopDownSurvivors.Player;

namespace TopDownSurvivors.UI
{
    public sealed class HUDController : MonoBehaviour, IFearObserver
    {
        [SerializeField] private HUDManager hudManager;
        [SerializeField] private FearTimerManager fearTimerManager;
        [SerializeField] private PlayerController player;

        private void OnEnable()
        {
            if (fearTimerManager != null)
            {
                fearTimerManager.Register(this);
            }
        }

        private void OnDisable()
        {
            if (fearTimerManager != null)
            {
                fearTimerManager.Unregister(this);
            }
        }

        public void OnFearChanged(FearContext context)
        {
            if (hudManager == null) return;

            if (hudManager.FearTimerView != null)
            {
                hudManager.FearTimerView.SetTime(context.ElapsedSeconds);
            }

            if (hudManager.FearLevelView != null)
            {
                hudManager.FearLevelView.SetFear(context.FearValue, context.CurrentRange);
            }
        }

        private void Update()
        {
            if (player == null || hudManager == null) return;

            if (hudManager.HealthView != null && player.Health != null)
            {
                hudManager.HealthView.SetHealth(player.Health.CurrentHealth, player.Health.MaxHealth);
            }

            var playerLevel = player.GetComponent<PlayerLevel>();
            if (playerLevel != null)
            {
                if (hudManager.XPBarView != null && player.Experience != null)
                {
                    hudManager.XPBarView.SetXP(player.Experience.CurrentXP, playerLevel.XPRequiredForNextLevel);
                }

                if (hudManager.LevelView != null)
                {
                    hudManager.LevelView.SetLevel(playerLevel.CurrentLevel);
                }
            }
        }
    }
}