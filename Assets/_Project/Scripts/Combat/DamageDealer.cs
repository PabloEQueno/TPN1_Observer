using UnityEngine;

namespace TopDownSurvivors.Combat
{
    public sealed class DamageDealer : MonoBehaviour
    {
        [SerializeField, Min(0f)] private float damage = 10f;

        public float Damage => damage;

        public void SetDamage(float value)
        {
            damage = Mathf.Max(0f, value);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                if (collision.TryGetComponent(out IDamageable damageable))
                {
                    damageable.TakeDamage(damage);
                    
                    Destroy(gameObject);
                }
            }
            else if (collision.CompareTag("Obstacle")) 
            {
                Destroy(gameObject);
            }
        }
    }
}