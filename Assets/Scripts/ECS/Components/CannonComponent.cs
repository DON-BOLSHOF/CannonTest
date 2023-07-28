using System;
using Behaviours;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct CannonComponent
    {
        public float Delay;
        
        public CannonBall CannonBall;
        public float CannonBallSpeed;
        public GameObject CannonBallSpawnPosition;
    }
}