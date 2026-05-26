using UnityEngine;
using TopDownSurvivors.Combat;
using TopDownSurvivors.Menus; // Añadimos el namespace de tus menús

namespace TopDownSurvivors.Player
{
    public sealed class PlayerHealth : DamageReceiver
    {
        [Header("UI References")]
        [SerializeField] private GameOverMenuController gameOverController; // Referencia a tu nuevo controlador

        private bool isDead = false;

        protected override void Awake()
        {
            base.Awake(); 
        }

        public override void TakeDamage(float amount)
        {
            if (isDead) return;

            base.TakeDamage(amount);

            if (CurrentHealth <= 0f && !isDead)
            {
                Die();
            }
        }

        private void Die()
        {
            isDead = true;
            
            // Pausamos el juego
            Time.timeScale = 0f;

            // Le avisamos al controlador del menú que se muestre
            if (gameOverController != null)
            {
                gameOverController.Show();
            }
            else
            {
                Debug.LogWarning("¡Falta asignar el GameOverMenuController en el componente PlayerHealth!");
            }
        }
    }
}