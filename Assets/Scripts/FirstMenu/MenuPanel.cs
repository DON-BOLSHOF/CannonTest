using UnityEngine;

namespace FirstMenu
{
    [RequireComponent(typeof(Animator))]
    public class MenuPanel : MonoBehaviour
    {
        private Animator _animator;
        
        private static readonly int OpenCreditsPanelKey = Animator.StringToHash("OpenCreditsPanel");

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void OpenCredits()
        {
            _animator.SetBool(OpenCreditsPanelKey, true);
        }

        public void CloseCredits()
        {
            _animator.SetBool(OpenCreditsPanelKey, false);
        }
    }
}