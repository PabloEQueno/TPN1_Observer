using UnityEngine;

namespace TopDownSurvivors.Player
{
    public sealed class PlayerLevel : MonoBehaviour
    {
        [SerializeField, Min(1)] private int currentLevel = 1;
        [SerializeField, Min(1)] private int xpRequiredForNextLevel = 10;

        public int CurrentLevel => currentLevel;
        public int XPRequiredForNextLevel => xpRequiredForNextLevel;
    }
}
