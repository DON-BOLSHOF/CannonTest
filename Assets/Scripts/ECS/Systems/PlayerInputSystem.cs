using System;
using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
using Zenject;

namespace ECS.Systems
{
    public class PlayerInputSystem : IEcsSystem, IEcsInitSystem, IEcsDestroySystem
    {
        [Inject] private SystemUtils _systemUtils;
        [Inject] private PlayerInputReader _playerInputReader;

        private EcsFilter<PlayerTag, RotationComponent> _rotationFilter;
        private EcsFilter<PlayerTag, CannonComponent> _fireFilter;
        private EcsFilter<PlayerTag> _playerFilter;

        public void Init()
        {
            _playerInputReader.OnMouseMoved += TurnOn;
            _playerInputReader.OnMouseClicked += Fire;
            _playerInputReader.OnQClicked += MegaBuff;
        }

        private void TurnOn(Vector2 value)
        {
            foreach (var i in _rotationFilter)
            {
                var lookPosition = _systemUtils.GetLookPosition(value);

                _rotationFilter.Get2(i).LookPosition = lookPosition;   
            }
        }

        private void Fire()
        {
            foreach (var i in _fireFilter)
            {
                ref var playerEntity = ref _fireFilter.GetEntity(i);
                playerEntity.Get<CannonFireEvent>();
            }
        }

        private void MegaBuff()
        {
            foreach (var i in _playerFilter)
            {
                ref var playerEntity = ref _playerFilter.GetEntity(i);
                playerEntity.Get<MegaBuffEvent>();
            }
        }

        public void Destroy()
        {
            _playerInputReader.OnMouseMoved -= TurnOn;
            _playerInputReader.OnMouseClicked -= Fire;
            _playerInputReader.OnQClicked -= MegaBuff;
        }
    }
}