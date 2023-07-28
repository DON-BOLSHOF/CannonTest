using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class DamageSystem : IEcsRunSystem
    {
        private EcsFilter<HealthComponent, DamageEvent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var damage = ref _filter.Get2(i).Damage;
                ref var health = ref _filter.Get1(i).HealthValue;

                health -= damage;

                if (health <= 0)
                    _filter.GetEntity(i).Get<DieEvent>();
            }
        }
    }
}