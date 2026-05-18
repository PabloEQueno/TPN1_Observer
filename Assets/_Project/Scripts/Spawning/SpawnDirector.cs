using TopDownSurvivors.Data;
using TopDownSurvivors.Fear;
using TopDownSurvivors.Enemies;
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

        private float nextSpawnTime;
        private Transform playerTransform; 
        private void Start()
        {
            var playerController = FindFirstObjectByType<TopDownSurvivors.Player.PlayerController>();
            if (playerController != null)
            {
                playerTransform = playerController.transform;
            }
        }

        private void Update()
        {
            if (spawnTable == null || monsterFactory == null || playerTransform == null) return;

            if (Time.time >= nextSpawnTime)
            {
                SpawnMonsterWave();
                nextSpawnTime = Time.time + spawnIntervalSeconds;
            }
        }

        private void SpawnMonsterWave()
        {
            
            MonsterDataSO selectedMonsterData = spawnTable.GetRandomMonster(CurrentFearContext.CurrentRange);

            if (selectedMonsterData == null) return;

            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPosition = playerTransform.position + new Vector3(randomDirection.x, randomDirection.y, 0f) * 10f;

            MonsterBase newMonster = monsterFactory.Create(selectedMonsterData, spawnPosition, enemyContainer);

            if (newMonster != null && newMonster.TryGetComponent(out EnemyMovement movement))
            {
                movement.SetTarget(playerTransform);
            }
        }

        public void OnFearChanged(FearContext context)
        {
            CurrentFearContext = context;
        }
    }
}