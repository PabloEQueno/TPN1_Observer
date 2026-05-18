using UnityEngine;
using TopDownSurvivors.Combat;

namespace TopDownSurvivors.Player
{
    public sealed class PlayerHealth : DamageReceiver
    {
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
            
            Time.timeScale = 0f;
        }
    }
}