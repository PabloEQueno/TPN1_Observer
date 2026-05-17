using UnityEngine;

namespace TopDownSurvivors.Enemies
{
    public sealed class EnemyDeathHandler : MonoBehaviour
    {
        [SerializeField] private EnemyXPDrop xpDrop;

        public EnemyXPDrop XPDrop => xpDrop;
    }
}
