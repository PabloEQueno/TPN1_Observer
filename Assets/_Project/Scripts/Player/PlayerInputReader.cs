using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDownSurvivors.Player
{
    public sealed class PlayerInputReader : MonoBehaviour
    {
        [SerializeField] private InputActionReference moveAction;

        public Vector2 Movement { get; private set; }

        private void OnEnable()
        {
            if (moveAction != null)
            {
                moveAction.action.Enable();
            }
        }

        private void OnDisable()
        {
            if (moveAction != null)
            {
                moveAction.action.Disable();
            }
        }

        public void ReadMovementForStructurePreview()
        {
            Movement = moveAction != null ? moveAction.action.ReadValue<Vector2>() : Vector2.zero;
        }
    }
}
