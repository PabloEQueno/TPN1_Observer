using UnityEngine;

namespace TopDownSurvivors.Enemies
{
    public sealed class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D body;
        [SerializeField] private Transform target;
        [SerializeField, Min(0f)] private float movementSpeed = 1f;

        public Rigidbody2D Body => body;
        public Transform Target => target;
        public float MovementSpeed => movementSpeed;

        public void SetTarget(Transform nextTarget)
        {
            target = nextTarget;
        }
    }
}
