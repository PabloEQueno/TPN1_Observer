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

        private int totalKills = 0;
        private int totalScore = 0;

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
                var textComponent = hudManager.FearTimerView.GetComponent<TMPro.TMP_Text>();
                if (textComponent != null)
                {
                    int minutes = Mathf.FloorToInt(Time.timeSinceLevelLoad / 60f);
                    int seconds = Mathf.FloorToInt(Time.timeSinceLevelLoad % 60f);
                    textComponent.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                }
            }

            if (hudManager.FearLevelView != null && fearTimerManager != null)
            {
                int currentFear = Mathf.FloorToInt(Time.timeSinceLevelLoad * 0.5f) % 101; 
                
                hudManager.FearLevelView.SetFear(currentFear, null);
            }
        }

        public void RegisterEnemyDeath(int scorePoints)
        {
            totalKills++;
            totalScore += Mathf.Max(0, scorePoints);

            if (hudManager != null)
            {
                if (hudManager.KillCounterView != null) 
                    hudManager.KillCounterView.SetKills(totalKills);

                if (hudManager.ScoreView != null) 
                    hudManager.ScoreView.SetScore(totalScore);
            }
        }

        private void Update()
        {
            if (player != null && hudManager != null)
            {
                var healthComponent = player.GetComponent<PlayerHealth>();
                if (healthComponent != null && hudManager.HealthView != null)
                {
                    hudManager.HealthView.SetHealth(healthComponent.CurrentHealth, healthComponent.MaxHealth);
                }

                var expComponent = player.GetComponent<PlayerExperience>();
                var levelComponent = player.GetComponent<PlayerLevel>();

                if (expComponent != null && levelComponent != null)
                {
                    if (hudManager.XPBarView != null)
                    {
                        hudManager.XPBarView.UpdateXP(expComponent.CurrentXP, levelComponent.XPRequiredForNextLevel);
                    }
                    
                    if (hudManager.LevelView != null)
                    {
                        hudManager.LevelView.SetLevel(levelComponent.CurrentLevel);
                    }
                }
            }        
        }
    }
}