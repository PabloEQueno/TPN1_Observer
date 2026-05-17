using UnityEngine;

namespace TopDownSurvivors.Enemies
{
    public sealed class EnemyXPDrop : MonoBehaviour
    {
        [SerializeField, Min(0)] private int xpAmount = 1;

        public int XPAmount => xpAmount;
    }
}
