using UnityEngine;

namespace TopDownSurvivors.Combat
{
    // Requerimos un Rigidbody2D para moverlo mediante el motor de físicas de forma limpia
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Projectile : MonoBehaviour
    {
        [SerializeField, Min(0f)] private float speed = 10f;
        [SerializeField, Min(0f)] private float lifetime = 3f;
        [SerializeField] private DamageDealer damageDealer;

        public float Speed => speed;
        public float Lifetime => lifetime;
        public DamageDealer DamageDealer => damageDealer;

        private Rigidbody2D rb;
        private Vector2 travelDirection;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            if (damageDealer == null) damageDealer = GetComponent<DamageDealer>();
            
            Destroy(gameObject, lifetime);
        }

        public void Initialize(Vector2 direction)
        {
            travelDirection = direction.normalized;

            float angle = Mathf.Atan2(travelDirection.y, travelDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        private void FixedUpdate()
        {
            if (rb != null)
            {
                rb.linearVelocity = travelDirection * speed;
            }
        }
    }
}