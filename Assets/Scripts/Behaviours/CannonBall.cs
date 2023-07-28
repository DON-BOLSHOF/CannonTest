using System;
using UnityEngine;

namespace Behaviours
{
    public class CannonBall : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _deathParticles;
        [field: SerializeField] public int Damage { get; private set; } = 10; 

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<ICannonBallVisitor>(out var visitor))
            {
                visitor.Visit(this);
            }
            
            var particleInstance = Instantiate(_deathParticles);
            particleInstance.transform.position = transform.position;
            
            Destroy(gameObject);
        }
    }
}