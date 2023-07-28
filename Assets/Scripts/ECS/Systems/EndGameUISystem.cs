using ECS.Components;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public class EndGameUISystem : IEcsRunSystem
    {
        private EcsFilter<EndGameEvent> _filter;
        private EcsFilter<EndGameUIComponent> _uiComponent;

        public void Run()
        {
            foreach (var i in _filter)
            {
                foreach (var j in _uiComponent)
                {
                    ref var panel = ref _uiComponent.Get1(j).UIPanel;
                    panel.SetActive(true);   
                }
            }
        }
    }
}