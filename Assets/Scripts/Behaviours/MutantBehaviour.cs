using System;
using Animations;
using ECS.Components;
using Leopotam.Ecs;
using UniRx;
using UnityEngine;

namespace Behaviours
{
    public class MutantBehaviour : MonoBehaviour, ICannonBallVisitor//Скрещивание GO и ECS
    {
        [SerializeField] private ParticleSystem _deadParticles;
        [SerializeField] private MutantAnimation _animation;
        
        private EntityReference _entityReference;

        private void Start()
        {
            _entityReference = GetComponent<EntityReference>();
            
            _animation.OnRise
                .Subscribe(_ => OnRose())
                .AddTo(this);

            _animation.OnDie
                .Subscribe(_ => OnDead())
                .AddTo(this);
        }

        private void OnRose()
        {
            _entityReference.Entity.Get<RoseEvent>();
        }

        private void OnDead()
        {
            Instantiate(_deadParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
        public void Visit(CannonBall ball)
        {
            _entityReference.Entity.Get<DamageEvent>().Damage = ball.Damage;
        }
    }

    public interface ICannonBallVisitor
    {
        void Visit(CannonBall ball);
    }
}