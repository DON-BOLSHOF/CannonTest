using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class CannonSystem : IEcsRunSystem
    {
        private EcsFilter<CannonComponent, CannonFireEvent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var entity = ref _filter.GetEntity(i);

                if (!entity.Has<DelayFireComponent>())
                {
                    ref var cannonBall = ref _filter.Get1(i).CannonBall;
                    ref var speed = ref _filter.Get1(i).CannonBallSpeed;
                    ref var delay = ref _filter.Get1(i).Delay;
                    ref var ballPosition = ref _filter.Get1(i).CannonBallSpawnPosition;

                    var instance = Object.Instantiate(cannonBall, ballPosition.transform);
                    instance.GetComponent<Rigidbody>().AddForce(instance.transform.forward * speed);
                    
                    entity.Get<DelayFireComponent>().Delay = delay;
                }
            }
        }
    }
}