using ECS.Components;
using Leopotam.Ecs;
using UniRx;
using Voody.UniLeo;

namespace ECS.Systems
{
    public class EndGameSystem :IEcsRunSystem, IEcsInitSystem, IEcsDestroySystem
    {
        private EcsFilter<MutantComponent> _mutantFilter;

        private ReactiveProperty<int> _mutantCount = new();
        private CompositeDisposable _disposable = new();

        public void Init()
        {
            _mutantCount.Where(count => count >= 10).Subscribe(_ => EndGame()).AddTo(_disposable);
        }

        private void EndGame()
        {
            WorldHandler.GetWorld().SendMessage(new EndGameEvent());
        }

        public void Run()
        {
            _mutantCount.Value = _mutantFilter.GetEntitiesCount();
        }

        public void Destroy()
        {
            _disposable.Dispose();
        }
    }
}