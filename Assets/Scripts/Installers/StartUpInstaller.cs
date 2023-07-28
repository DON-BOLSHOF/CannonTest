using ECS;
using ECS.Systems;
using Leopotam.Ecs;
using Zenject;

namespace Installers
{
    public class StartUpInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInstance(new EcsWorld());

            Container.Bind<PlayerInputSystem>().AsSingle();

            Container.BindInterfacesAndSelfTo<StartUpExecutor>().AsSingle().NonLazy();
        }
    }
}