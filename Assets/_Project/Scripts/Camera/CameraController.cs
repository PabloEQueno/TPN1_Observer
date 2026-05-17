using UnityEngine;

namespace TopDownSurvivors.CameraSystem
{
    public sealed class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset = new(0f, 0f, -10f);
        [SerializeField, Min(0f)] private float followSpeed = 8f;

        public Transform Target => target;
        public Vector3 Offset => offset;
        public float FollowSpeed => followSpeed;

        public void SetTarget(Transform nextTarget)
        {
            target = nextTarget;
        }

        private void LateUpdate()
        {
            if (target == null) return;

            Vector3 targetPosition = target.position + offset;

            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}