using TopDownSurvivors.Combat;
using UnityEngine;

namespace TopDownSurvivors.Player
{
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerMovement movement;
        [SerializeField] private PlayerHealth health;
        [SerializeField] private PlayerExperience experience;
        [SerializeField] private AutomaticShooter automaticShooter;

        public PlayerMovement Movement => movement;
        public PlayerHealth Health => health;
        public PlayerExperience Experience => experience;
        public AutomaticShooter AutomaticShooter => automaticShooter;
    }
}
