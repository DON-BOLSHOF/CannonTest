using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class CursorUnLockSystem : IEcsRunSystem
    {
        private EcsFilter<EndGameEvent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}