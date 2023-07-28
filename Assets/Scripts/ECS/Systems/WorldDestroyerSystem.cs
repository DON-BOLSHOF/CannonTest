using ECS.Components;
using Leopotam.Ecs;
using Voody.UniLeo;

namespace ECS.Systems
{
    public class WorldDestroyerSystem : IEcsRunSystem
    {
        private EcsFilter<EndGameEvent> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                WorldHandler.GetWorld().Destroy();
            }
        }
    }
}