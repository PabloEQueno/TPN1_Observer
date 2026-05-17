using UnityEngine;

namespace TopDownSurvivors.Combat
{
    public sealed class WeaponStats : MonoBehaviour
    {
        [SerializeField, Min(0f)] private float damage = 5f;
        [SerializeField, Min(0.01f)] private float shotsPerSecond = 1f;

        public float Damage => damage;
        public float ShotsPerSecond => shotsPerSecond;

        public void AddDamage(float amount)
        {
            damage = Mathf.Max(0f, damage + amount);
        }

        public void AddShotsPerSecond(float amount)
        {
            shotsPerSecond = Mathf.Max(0.01f, shotsPerSecond + amount);
        }
    }
}
