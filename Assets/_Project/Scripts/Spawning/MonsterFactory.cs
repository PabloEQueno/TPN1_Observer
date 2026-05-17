using TopDownSurvivors.Data;
using TopDownSurvivors.Enemies;
using UnityEngine;

namespace TopDownSurvivors.Spawning
{
    public sealed class MonsterFactory : MonoBehaviour, IMonsterFactory
    {
        public MonsterBase Create(MonsterDataSO monsterData, Vector3 position, Transform parent)
        {
            if (monsterData == null || monsterData.Prefab == null)
            {
                return null;
            }

            GameObject instance = Instantiate(monsterData.Prefab, position, Quaternion.identity, parent);
            MonsterBase monster = instance.GetComponent<MonsterBase>();
            monster?.Configure(monsterData);
            return monster;
        }
    }
}
