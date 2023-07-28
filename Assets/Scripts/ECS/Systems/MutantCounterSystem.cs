using ECS.Components;
using Leopotam.Ecs;
using UniRx;
using UnityEngine;

namespace ECS.Systems
{
    public class MutantCounterSystem: IEcsRunSystem, IEcsInitSystem, IEcsDestroySystem
    {
        private EcsFilter<MutantComponent> _mutantFilter;
        private EcsFilter<MutantCounterComponent> _counterFilter;

        private ReactiveProperty<int> _count = new();
        private CompositeDisposable _disposable = new();
        
        
        public void Init()
        {
            _count
                .Subscribe(i => ChangeDescription(i))
                .AddTo(_disposable);
        }

        private void ChangeDescription(int value)
        {
            foreach (var i in _counterFilter)
            {
                ref var description = ref _counterFilter.Get1(i).Description;
                description.text = value.ToString();
            }
        }

        public void Run()
        {
            _count.Value = _mutantFilter.GetEntitiesCount();
        }

        public void Destroy()
        {
            _disposable.Dispose();
        }
    }
}