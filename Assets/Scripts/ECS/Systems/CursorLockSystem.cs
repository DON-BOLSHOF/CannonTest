using Leopotam.Ecs;
using UnityEditor;
using UnityEngine;

namespace ECS.Systems
{
    public class CursorLockSystem : IEcsInitSystem
    {
        public void Init()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}