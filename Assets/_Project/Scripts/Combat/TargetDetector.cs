using UnityEngine;

namespace TopDownSurvivors.Combat
{
    public sealed class TargetDetector : MonoBehaviour, ITargetProvider
    {
        [SerializeField, Min(0f)] private float detectionRadius = 8f;
        [SerializeField] private LayerMask targetLayers;
        [SerializeField] private Transform currentTarget;

        public float DetectionRadius => detectionRadius;
        public LayerMask TargetLayers => targetLayers;
        public Transform CurrentTarget => currentTarget;

        public void SetCurrentTarget(Transform target)
        {
            currentTarget = target;
        }
        private void Update()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, targetLayers);
            
            Transform closestEnemy = null;
            float minDistance = Mathf.Infinity;

            foreach (Collider2D col in colliders)
            {
                float distance = Vector2.Distance(transform.position, col.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestEnemy = col.transform;
                }
            }

            currentTarget = closestEnemy;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }
}