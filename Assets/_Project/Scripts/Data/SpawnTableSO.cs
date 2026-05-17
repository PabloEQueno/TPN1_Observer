using System;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownSurvivors.Data
{
    [CreateAssetMenu(fileName = "SpawnTable", menuName = "Top Down Survivors/Spawning/Spawn Table")]
    public sealed class SpawnTableSO : ScriptableObject
    {
        [SerializeField] private List<SpawnEntry> entries = new();

        public IReadOnlyList<SpawnEntry> Entries => entries;

        [Serializable]
        public sealed class SpawnEntry
        {
            [SerializeField] private MonsterDataSO monster;
            [SerializeField, Min(0f)] private float weight = 1f;

            public MonsterDataSO Monster => monster;
            public float Weight => weight;
        }
    }
}
