using UnityEngine;

namespace TopDownSurvivors.Data
{
    [CreateAssetMenu(fileName = "MonsterData", menuName = "Top Down Survivors/Enemies/Monster Data")]
    public sealed class MonsterDataSO : ScriptableObject
    {
        [SerializeField] private string monsterName;
        [SerializeField] private GameObject prefab;
        [SerializeField, Min(1f)] private float maxHealth = 10f;
        [SerializeField, Min(0f)] private float movementSpeed = 2f;
        [SerializeField, Min(0f)] private float contactDamage = 1f;
        [SerializeField, Min(0)] private int xpDrop = 1;
        [SerializeField, Range(0, 100)] private int minimumFearValue;
        [SerializeField, Range(0, 100)] private int maximumFearValue = 25;
        [SerializeField, Min(0f)] private float spawnWeight = 1f;

        public string MonsterName => monsterName;
        public GameObject Prefab => prefab;
        public float MaxHealth => maxHealth;
        public float MovementSpeed => movementSpeed;
        public float ContactDamage => contactDamage;
        public int XPDrop => xpDrop;
        public int MinimumFearValue => minimumFearValue;
        public int MaximumFearValue => maximumFearValue;
        public float SpawnWeight => spawnWeight;

        public bool CanSpawnAtFear(int fearValue)
        {
            return fearValue >= minimumFearValue && fearValue <= maximumFearValue;
        }
    }
}
