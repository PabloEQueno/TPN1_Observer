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

        public MonsterDataSO GetRandomMonster(FearRangeSO currentRange)
        {
            if (entries == null || entries.Count == 0) return null;

            float totalWeight = 0f;
            foreach (var entry in entries)
            {
                if (entry.Monster != null)
                {
                    totalWeight += entry.Weight;
                }
            }

            if (totalWeight <= 0f) return null;

            float randomPoint = UnityEngine.Random.Range(0f, totalWeight);

            float currentWeightSum = 0f;
            foreach (var entry in entries)
            {
                if (entry.Monster != null)
                {
                    currentWeightSum += entry.Weight;
                    if (randomPoint <= currentWeightSum)
                    {
                        return entry.Monster;
                    }
                }
            }

            return entries[0].Monster;
        }

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