using UnityEngine;

namespace TopDownSurvivors.Player
{
    public sealed class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerInputReader inputReader;
        [SerializeField] private Rigidbody2D body;
        [SerializeField, Min(0f)] private float movementSpeed = 5f;

        public PlayerInputReader InputReader => inputReader;
        public Rigidbody2D Body => body;
        public float MovementSpeed => movementSpeed;
    }
}
