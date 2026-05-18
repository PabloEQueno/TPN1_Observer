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
        [SerializeField, Min(0f)] private float baseSpawnInterval = 2f;

        [Header("Dificultad Demencial")]
        [SerializeField] private float difficultyRampSpeed = 0.05f; 
        [SerializeField] private int baseMonstersPerWave = 1;     

        public SpawnTableSO SpawnTable => spawnTable;
        public IMonsterFactory MonsterFactory => monsterFactory;
        public Transform EnemyContainer => enemyContainer;
        
        private float currentSpawnInterval;
        private float nextSpawnTime;
        private Transform playerTransform;
        private float timeElapsed;

        public FearContext CurrentFearContext { get; private set; }

        private void Start()
        {
            currentSpawnInterval = baseSpawnInterval;
            var playerController = FindFirstObjectByType<TopDownSurvivors.Player.PlayerController>();
            if (playerController != null) playerTransform = playerController.transform;
        }

        private void Update()
        {
            if (spawnTable == null || monsterFactory == null || playerTransform == null) return;

            timeElapsed += Time.deltaTime;

            currentSpawnInterval = Mathf.Max(0.15f, baseSpawnInterval - (timeElapsed * difficultyRampSpeed * 0.2f));

            if (Time.time >= nextSpawnTime)
            {
                int monstersToSpawn = baseMonstersPerWave + Mathf.FloorToInt(timeElapsed * difficultyRampSpeed);

                for (int i = 0; i < monstersToSpawn; i++)
                {
                    SpawnSingleMonster();
                }

                nextSpawnTime = Time.time + currentSpawnInterval;
            }
        }

        private void SpawnSingleMonster()
        {
            MonsterDataSO selectedMonsterData = spawnTable.GetRandomMonster(CurrentFearContext.CurrentRange);
            if (selectedMonsterData == null) return;

            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            float spawnDistance = Random.Range(9f, 12f);
            Vector3 spawnPosition = playerTransform.position + new Vector3(randomDirection.x, randomDirection.y, 0f) * spawnDistance;

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