using ECS.Components;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public class UIBuffSystem : IEcsRunSystem
    {
        private EcsFilter<UIBuffComponent> _UIBuffFilter;
        private EcsFilter<DelayBuffComponent> _delayFilter;

        public void Run()
        {
            foreach (var i in _delayFilter)
            {
                ref var image = ref _UIBuffFilter.Get1(i).Image;
                
                foreach (var j in _UIBuffFilter)
                {
                    image.fillAmount = 1 - _delayFilter.Get1(j).CurrentDelay / _delayFilter.Get1(j).DefaultDelay;
                }    
            }
        }
    }
}