using UnityEngine;

namespace TopDownSurvivors.Enemies
{
    public sealed class EnemyAttack : MonoBehaviour
    {
        [SerializeField, Min(0f)] private float contactDamage = 1f;
        [SerializeField, Min(0f)] private float attackCooldown = 1f;

        public float ContactDamage => contactDamage;
        public float AttackCooldown => attackCooldown;
    }
}
