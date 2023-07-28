using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    private PlayerInput _playerInput;

    public Action<Vector2> OnMouseMoved;
    public Action OnMouseClicked;
    public Action OnQClicked;

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Start()
    {
        _playerInput.Mouse.MouseRotation.started += OnMouseMove;
        _playerInput.Mouse.LeftClickMouse.started += OnMouseClick;
        _playerInput.KeyBoard.Q.started += OnQClick;
    }

    private void OnMouseMove(InputAction.CallbackContext value)
    {
        var t = value.ReadValue<Vector2>();

        OnMouseMoved?.Invoke(t);
    }

    private void OnMouseClick(InputAction.CallbackContext value)
    {
        OnMouseClicked?.Invoke();
    }

    private void OnQClick(InputAction.CallbackContext value)
    {
        OnQClicked?.Invoke();
    }

    private void OnDestroy()
    {
        _playerInput.Mouse.MouseRotation.started -= OnMouseMove;
        _playerInput.Mouse.LeftClickMouse.started -= OnMouseClick;
    }
}
