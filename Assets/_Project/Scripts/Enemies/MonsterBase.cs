using TopDownSurvivors.Data;
using UnityEngine;

namespace TopDownSurvivors.Enemies
{
    public class MonsterBase : MonoBehaviour
    {
        [SerializeField] private MonsterDataSO data;

        public MonsterDataSO Data => data;

        public virtual void Configure(MonsterDataSO monsterData)
        {
            data = monsterData;
        }
    }
}
