using System;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct DieableComponent
    {
        public GameObject DeadObject;
        public ParticleSystem DieParticle;
    }
}