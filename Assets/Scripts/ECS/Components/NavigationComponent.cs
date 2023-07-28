using System;
using UnityEngine;
using UnityEngine.AI;

namespace ECS.Components
{
    [Serializable]
    public struct NavigationComponent
    {
        public float Speed;
        public NavMeshAgent Agent;
        public LayerMask LayerMask;
        public float PathEndThreshold;
    }
}