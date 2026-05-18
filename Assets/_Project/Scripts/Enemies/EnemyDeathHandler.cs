using UnityEngine;
using TopDownSurvivors.Player; // Necesario para buscar al jugador y sumarle XP

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

            PlayerExperience playerXP = FindFirstObjectByType<PlayerExperience>();
            if (playerXP != null && xpDrop != null)
            {
                playerXP.AddXP(xpDrop.XPAmount);
            }

            Destroy(gameObject);
        }
    }
}