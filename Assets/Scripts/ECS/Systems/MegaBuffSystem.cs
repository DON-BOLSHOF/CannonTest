using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class MegaBuffSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerTag, MegaBuffEvent>.Exclude<DelayBuffComponent> _buffFilter;
        private EcsFilter<MutantComponent, HealthComponent> _mutantsFilter;
        private EcsFilter<SpawnComponent> _spawnFilter;

        public void Run()
        {
            foreach (var i in _buffFilter)
            {
                foreach (var j in _mutantsFilter)
                {
                    _mutantsFilter.GetEntity(j).Get<DieEvent>();
                }

                foreach (var j in _spawnFilter)
                {
                    ref var delay = ref _spawnFilter.Get1(i).DelayBetweenSpawn;
                    _spawnFilter.GetEntity(j).Get<DelaySpawnComponent>().Delay = delay;
                }

                _buffFilter.GetEntity(i).Get<DelayBuffComponent>().DefaultDelay = 10;
                _buffFilter.GetEntity(i).Get<DelayBuffComponent>().CurrentDelay =
                    _buffFilter.GetEntity(i).Get<DelayBuffComponent>().DefaultDelay;
            }
        }
    }
}