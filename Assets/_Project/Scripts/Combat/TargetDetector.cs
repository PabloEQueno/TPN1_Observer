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
    }
}
