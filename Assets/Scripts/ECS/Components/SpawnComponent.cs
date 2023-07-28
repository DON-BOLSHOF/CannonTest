using System;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct SpawnComponent
    {
        public GameObject GameObjectToSpawn;
        public Transform[] PositionsToSpawn;
        public float DelayBetweenSpawn;
    }
}