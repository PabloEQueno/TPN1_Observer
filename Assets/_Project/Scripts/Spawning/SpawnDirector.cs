using TopDownSurvivors.Data;
using TopDownSurvivors.Fear;
using UnityEngine;

namespace TopDownSurvivors.Spawning
{
    public sealed class SpawnDirector : MonoBehaviour, IFearObserver
    {
        [SerializeField] private SpawnTableSO spawnTable;
        [SerializeField] private MonsterFactory monsterFactory;
        [SerializeField] private Transform enemyContainer;
        [SerializeField, Min(0f)] private float spawnIntervalSeconds = 2f;

        public SpawnTableSO SpawnTable => spawnTable;
        public IMonsterFactory MonsterFactory => monsterFactory;
        public Transform EnemyContainer => enemyContainer;
        public float SpawnIntervalSeconds => spawnIntervalSeconds;
        public FearContext CurrentFearContext { get; private set; }

        public void OnFearChanged(FearContext context)
        {
            CurrentFearContext = context;
        }
    }
}
