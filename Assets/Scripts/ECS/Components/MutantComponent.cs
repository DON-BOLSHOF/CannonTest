using System;
using Animations;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct MutantComponent
    {
        public MutantAnimation Animator;
    }
}