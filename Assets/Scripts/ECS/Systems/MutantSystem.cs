using ECS.Components;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public class MutantSystem : IEcsRunSystem
    {
        private EcsFilter<MutantComponent, RoseEvent, NavigationBlockEvent> _roseMutants;
        private EcsFilter<MutantComponent, DieEvent> _dieFilter;

        public void Run()
        {
            foreach (var i in _roseMutants)
            {
                ref var entity = ref _roseMutants.GetEntity(i);
                ref var animator = ref _roseMutants.Get1(i);
                
                entity.Del<NavigationBlockEvent>();
                animator.Animator.SetRun();
            }

            foreach (var i in _dieFilter)
            {
                ref var entity = ref _dieFilter.GetEntity(i);

                entity.Get<NavigationBlockEvent>();
                ref var animator = ref _dieFilter.Get1(i);
                animator.Animator.SetDie();
                entity.Destroy();
            }
        }
    }
}