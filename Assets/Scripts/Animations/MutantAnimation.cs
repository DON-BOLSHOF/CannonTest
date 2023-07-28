using System;
using UniRx;
using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(Animator))]
    public class MutantAnimation : MonoBehaviour
    {
        private Animator _animator;

        public ReactiveCommand OnRise = new();
        public ReactiveCommand OnDie= new();
        
        private static readonly int RunKey = Animator.StringToHash("Run");
        private static readonly int DieKey = Animator.StringToHash("Die");

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnRose()
        {
            OnRise?.Execute();
        }

        private void OnDead()
        {
            OnDie?.Execute();
        }

        public void SetRun()
        {
            _animator.SetTrigger(RunKey);
        }

        public void SetDie()
        {
            _animator.SetBool(DieKey, true);
        }
    }
}