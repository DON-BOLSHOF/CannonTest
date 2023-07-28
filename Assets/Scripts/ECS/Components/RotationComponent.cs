using System;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct RotationComponent
    {
        [HideInInspector] public Vector3 LookPosition;
        public float Speed;
    }
}