using System;
using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class GameCycleSystem : IEcsRunSystem
    {
        private EcsFilter<GameCycleComponent>.Exclude<DelayComponent> _cycleFilter;

        private EcsFilter<SpawnComponent> _spawnFilter;
        private EcsFilter<NavigationComponent> _navigationFilter;
        private EcsFilter<CannonComponent> _cannonFilter;
        private EcsFilter<HealthComponent> _healthFilter;

        public void Run()
        {
            foreach (var i in _cycleFilter)
            {
                ref var buffValue = ref _cycleFilter.Get1(i).BuffComponentsValue;

                Debug.Log(buffValue);
                
                foreach (var j in _spawnFilter)
                {
                   ref var delay = ref _spawnFilter.Get1(j).DelayBetweenSpawn;
                   if (delay > 1) delay -= buffValue;
                }
                foreach (var j in _navigationFilter)
                {
                   ref var speed = ref _navigationFilter.Get1(j).Speed;
                   if (speed < 30) speed += buffValue;
                }
                foreach (var j in _cannonFilter)
                {
                   ref var delay = ref _cannonFilter.Get1(j).Delay;
                   if (delay > 1) delay -= buffValue;
                }  
                foreach (var j in _healthFilter)
                {
                   ref var delay = ref _healthFilter.Get1(j).HealthValue;
                   if (delay < 30) delay += buffValue;
                }
                
                _cycleFilter.GetEntity(i).Get<DelayComponent>().Delay = _cycleFilter.Get1(i).Delay;
            }
        }
    }
}