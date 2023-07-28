using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class DelaySystem : IEcsRunSystem
    {
        private EcsFilter<DelayBuffComponent> _delayBuffFilter;
        private EcsFilter<DelaySpawnComponent> _delaySpawnFilter;
        private EcsFilter<DelayFireComponent> _delayFireFilter;
        private EcsFilter<DelayComponent> _delayFilter;

        public void Run()
        {
            foreach (var i in _delayBuffFilter)
            {
                ref var entity = ref _delayBuffFilter.GetEntity(i);
                ref var delayComponent = ref _delayBuffFilter.Get1(i);
                delayComponent.CurrentDelay -= Time.deltaTime;

                if (delayComponent.CurrentDelay <= 0)
                {
                    entity.Del<DelayBuffComponent>();
                }
            }
            foreach (var i in _delaySpawnFilter)
            {
                ref var entity = ref _delaySpawnFilter.GetEntity(i);
                ref var delayComponent = ref _delaySpawnFilter.Get1(i);
                delayComponent.Delay -= Time.deltaTime;

                if (delayComponent.Delay <= 0)
                {
                    entity.Del<DelaySpawnComponent>();
                }
            }
            foreach (var i in _delayFireFilter)
            {
                ref var entity = ref _delayFireFilter.GetEntity(i);
                ref var delayComponent = ref _delayFireFilter.Get1(i);
                delayComponent.Delay -= Time.deltaTime;

                if (delayComponent.Delay <= 0)
                {
                    entity.Del<DelayFireComponent>();
                }
            }
            foreach (var i in _delayFilter)
            {
                ref var entity = ref _delayFilter.GetEntity(i);
                ref var delayComponent = ref _delayFilter.Get1(i);
                delayComponent.Delay -= Time.deltaTime;

                if (delayComponent.Delay <= 0)
                {
                    entity.Del<DelayComponent>();
                }
            }
        }
    }
}