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
    }
}
