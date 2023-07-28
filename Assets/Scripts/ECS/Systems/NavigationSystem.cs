using System;
using ECS.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace ECS.Systems
{
    public class NavigationSystem : IEcsRunSystem
    {
        private EcsFilter<NavigationComponent>.Exclude<NavigationBlockEvent> _navigationFilter;
        private EcsFilter<NavigationComponent, NavigationBlockEvent> _blockedFilter;

        public void Run()
        {
            foreach (var i in _blockedFilter)
            {
                ref var agent = ref _navigationFilter.Get1(i).Agent;

                if (agent.hasPath)
                    agent.Stop();
            }

            foreach (var i in _navigationFilter)
            {
                ref var agent = ref _navigationFilter.Get1(i).Agent;
                ref var speed = ref _navigationFilter.Get1(i).Speed;

                agent.speed = speed;

                ref var pathMask = ref _navigationFilter.Get1(i).LayerMask;

                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    agent.SetDestination(RandomNavmeshLocation(agent.transform.position, pathMask, 20));
                }
            }
        }
        
        private Vector3 RandomNavmeshLocation(Vector3 position, LayerMask mask, float radius)
        {
            var randomDirection = Random.insideUnitSphere * radius + position;

            var finalPosition = Vector3.zero;

            if (NavMesh.SamplePosition(randomDirection, out var hit, radius, mask))
            {
                finalPosition = hit.position;
            }

            Debug.DrawRay(finalPosition,Vector3.down,Color.blue,30.0f);
            Debug.DrawLine(position, finalPosition, Color.black, Mathf.Infinity);
            
            return finalPosition;
        }
    }
}