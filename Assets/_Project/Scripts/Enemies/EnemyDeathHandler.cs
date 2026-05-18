using UnityEngine;
using TopDownSurvivors.Player;
using TopDownSurvivors.UI;

namespace TopDownSurvivors.Enemies
{
    public sealed class EnemyDeathHandler : MonoBehaviour
    {
        [SerializeField] private EnemyXPDrop xpDrop;

        public EnemyXPDrop XPDrop => xpDrop;

        private bool isDead = false;

        public void HandleDeath()
        {
            if (isDead) return; 
            isDead = true;

            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null && playerObj.TryGetComponent(out PlayerExperience playerXP))
            {
                int xpGained = xpDrop != null ? xpDrop.XPAmount : 5;
                playerXP.AddXP(xpGained);
            }

            HUDController hud = FindFirstObjectByType<HUDController>();
            if (hud != null)
            {
                hud.RegisterEnemyDeath(100); 
            }

            Destroy(gameObject);
        }
    }
}