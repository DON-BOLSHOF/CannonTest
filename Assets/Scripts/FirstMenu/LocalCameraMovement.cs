using UnityEngine;

namespace FirstMenu
{
    public class LocalCameraMovement : MonoBehaviour
    {
        [SerializeField] private PlayerInputReader _playerInput;
        [SerializeField] private float _rotateSpeed;

        private Camera _camera;
    
        private void Start()
        {
            _camera = Camera.main;
        
            _playerInput.OnMouseMoved += MoveCamera;
        }

        private void MoveCamera(Vector2 value)
        {
            var mouseViewportPosition = _camera.ViewportToWorldPoint(new Vector3(value.x, value.y, _camera.transform.position.z));

            var targetRotation = Quaternion.LookRotation(mouseViewportPosition - transform.position);

            var rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotateSpeed * Time.deltaTime);
            transform.rotation = rotation;
        }


        private void OnDestroy()
        {
            _playerInput.OnMouseMoved -= MoveCamera;
        }
    }
}