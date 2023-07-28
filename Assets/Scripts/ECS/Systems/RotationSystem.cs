using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class RotationSystem : IEcsRunSystem
    {
        private EcsFilter<ModelComponent, RotationComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var modelTransform = ref _filter.Get1(i).ModelTransform;

                ref var positionToLookAt = ref _filter.Get2(i).LookPosition;
                ref var rotateSpeed = ref _filter.Get2(i).Speed;

                var targetRotation = Quaternion.LookRotation(positionToLookAt - modelTransform.position);

                var rotation = Quaternion.Slerp(modelTransform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
                modelTransform.rotation = rotation;
            }
        }
    }
}