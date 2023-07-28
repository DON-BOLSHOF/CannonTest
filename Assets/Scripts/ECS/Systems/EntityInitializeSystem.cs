using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class EntityInitializeSystem : IEcsRunSystem
    {
        private EcsFilter<InitializeEntityRequest> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var entity = ref _filter.GetEntity(i);
                ref var request = ref _filter.Get1(i);

                request.EntityReference.Entity = entity;
            }
        }
    }
}