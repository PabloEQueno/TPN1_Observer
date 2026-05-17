using TopDownSurvivors.Data;
using TopDownSurvivors.Enemies;
using UnityEngine;

namespace TopDownSurvivors.Spawning
{
    public interface IMonsterFactory
    {
        MonsterBase Create(MonsterDataSO monsterData, Vector3 position, Transform parent);
    }
}
