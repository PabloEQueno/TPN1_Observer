using UnityEngine;

namespace TopDownSurvivors.Combat
{
    public sealed class Projectile : MonoBehaviour
    {
        [SerializeField, Min(0f)] private float speed = 10f;
        [SerializeField, Min(0f)] private float lifetime = 3f;
        [SerializeField] private DamageDealer damageDealer;

        public float Speed => speed;
        public float Lifetime => lifetime;
        public DamageDealer DamageDealer => damageDealer;
    }
}
