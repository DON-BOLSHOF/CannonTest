using System;
using ECS.Components;
using ECS.Systems;
using Leopotam.Ecs;
using Voody.UniLeo;
using Zenject;

namespace ECS
{
    public class StartUpExecutor : IInitializable, ITickable, IDisposable
    {
        [Inject] private EcsWorld _ecsWorld;
        [Inject] private PlayerInputSystem _playerInputSystem;
        
        private EcsWorld _world;
        private EcsSystems _systems;

        public void Initialize()
        {
            _systems = new EcsSystems(_ecsWorld);
            _world = _ecsWorld;

            _systems.ConvertScene();

            AddSystems();

            AddOneFrames();
            
            _systems.Init();
        }

        private void AddSystems()
        {
            _systems
                .Add(new EntityInitializeSystem())
                .Add(new CursorLockSystem())
                .Add(new RotationSystem())
                .Add(_playerInputSystem)
                .Add(new DelaySystem())
                .Add(new CannonSystem())
                .Add(new MegaBuffSystem())
                .Add(new DamageSystem())
                .Add(new MutantSystem())
                .Add(new NavigationSystem())
                .Add(new SpawnSystem())
                .Add(new MutantCounterSystem())
                .Add(new UIBuffSystem())
                .Add(new MutantSystem())
                .Add(new GameCycleSystem())
                .Add(new EndGameSystem())
                .Add(new CursorUnLockSystem())
                .Add(new EndGameUISystem())
                .Add(new WorldDestroyerSystem())
                ;
        }

        private void AddOneFrames()
        {
            _systems
                .OneFrame<InitializeEntityRequest>()
                .OneFrame<CannonFireEvent>()
                .OneFrame<DamageEvent>()
                .OneFrame<RoseEvent>()
                .OneFrame<DieEvent>()
                .OneFrame<MegaBuffEvent>()
                ;
        }

        public void Tick()
        {
            _systems.Run();
        }

        public void Dispose()
        {
            _systems.Destroy();
            _world.Destroy();
        }
    }
}