using UnityEngine;
using Zenject;

namespace Installers
{
    public class PlayerInputReaderInstaller : MonoInstaller
    {
        [SerializeField] private PlayerInputReader _instance;
        public override void InstallBindings()
        {
            Container.Bind<PlayerInputReader>().FromInstance(_instance).AsSingle();
        }
    }
}