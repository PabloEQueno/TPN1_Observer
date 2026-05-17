using UnityEngine;

namespace TopDownSurvivors.Combat
{
    public class DamageReceiver : MonoBehaviour, IDamageable
    {
        [SerializeField, Min(1f)] private float maxHealth = 1f;

        public float MaxHealth => maxHealth;
        public float CurrentHealth { get; protected set; }
        public bool IsAlive => CurrentHealth > 0f;

        protected virtual void Awake()
        {
            CurrentHealth = maxHealth;
        }

        public virtual void TakeDamage(float amount)
        {
            CurrentHealth = Mathf.Max(0f, CurrentHealth - Mathf.Max(0f, amount));
        }
    }
}
