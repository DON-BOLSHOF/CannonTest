using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class SpawnSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter<SpawnComponent>.Exclude<DelaySpawnComponent> _filter;

        public void Init()
        {
            foreach (var i in _filter)
            {
                _filter.GetEntity(i).Get<DelaySpawnComponent>().Delay = 3f;
            }
        }

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var go = ref _filter.Get1(i).GameObjectToSpawn;
                ref var positions = ref _filter.Get1(i).PositionsToSpawn;
                ref var delay = ref _filter.Get1(i).DelayBetweenSpawn;

                var transform = positions[Random.Range(0, positions.Length)];
                Object.Instantiate(go, transform.position, transform.rotation);

                _filter.GetEntity(i).Get<DelaySpawnComponent>().Delay = delay;
            }
        }
    }
}