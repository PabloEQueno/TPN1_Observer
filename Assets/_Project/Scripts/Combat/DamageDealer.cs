using UnityEngine;

namespace TopDownSurvivors.Combat
{
    public sealed class DamageDealer : MonoBehaviour
    {
        [SerializeField, Min(0f)] private float damage = 1f;

        public float Damage => damage;

        public void SetDamage(float value)
        {
            damage = Mathf.Max(0f, value);
        }
    }
}
