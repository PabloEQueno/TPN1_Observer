using UnityEngine;

namespace TopDownSurvivors.Combat
{
    public sealed class AutomaticShooter : MonoBehaviour
    {
        [SerializeField] private WeaponStats weaponStats;
        [SerializeField] private TargetDetector targetDetector;
        [SerializeField] private Projectile projectilePrefab;
        [SerializeField] private Transform firePoint;

        public WeaponStats WeaponStats => weaponStats;
        public TargetDetector TargetDetector => targetDetector;
        public Projectile ProjectilePrefab => projectilePrefab;
        public Transform FirePoint => firePoint;

        private float nextFireTime;

        private void Update()
        {
            if (targetDetector == null || projectilePrefab == null) return;

            if (targetDetector.CurrentTarget != null)
            {
                if (Time.time >= nextFireTime)
                {
                    Shoot(targetDetector.CurrentTarget);

                    float cooldown = 0.5f; 

                    if (weaponStats != null && weaponStats.ShotsPerSecond > 0f)
                    {
                        cooldown = 1f / weaponStats.ShotsPerSecond;
                    }

                    nextFireTime = Time.time + cooldown;
                }
            }
        }

        private void Shoot(Transform target)
        {
            Vector3 spawnPosition = firePoint != null ? firePoint.position : transform.position;
            Projectile newProjectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

            if (newProjectile != null)
            {
                Vector2 direction = ((Vector2)target.position - (Vector2)spawnPosition).normalized;
                newProjectile.Initialize(direction);
                
                if (weaponStats != null && newProjectile.DamageDealer != null)
                {
                    newProjectile.DamageDealer.SetDamage(weaponStats.Damage);
                }
            }
        }
    }
}