using Zenject;

namespace Installers
{
    public class SystemUtilsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SystemUtils>().AsSingle();
        }
    }
}