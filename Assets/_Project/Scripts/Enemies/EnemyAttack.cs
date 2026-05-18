using UnityEngine;
using TopDownSurvivors.Player; 

namespace TopDownSurvivors.Enemies
{
    public sealed class EnemyAttack : MonoBehaviour
    {
        [SerializeField, Min(0f)] private float contactDamage = 10f;
        [SerializeField, Min(0f)] private float attackCooldown = 1f;

        public float ContactDamage => contactDamage;
        public float AttackCooldown => attackCooldown;

        private float nextAttackTime;

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out PlayerHealth playerHealth))
            {
                if (Time.time >= nextAttackTime)
                {
                    playerHealth.TakeDamage(contactDamage);
                    nextAttackTime = Time.time + attackCooldown;
                }
            }
        }
    }
}