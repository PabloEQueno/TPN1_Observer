using System.Collections.Generic;
using UnityEngine;

namespace TopDownSurvivors.Utilities
{
    public sealed class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform container;

        private readonly Queue<GameObject> inactiveObjects = new();

        public GameObject Prefab => prefab;
        public Transform Container => container;
        public int InactiveCount => inactiveObjects.Count;
    }
}
