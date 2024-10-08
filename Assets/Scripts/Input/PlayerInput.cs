using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerInputAction inputActions;

    public Action<Vector2, bool> onInput;
    public Action<float> onRun;
    public Action<float> onJump;

    private void Awake()
    {
        inputActions = new PlayerInputAction();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
        inputActions.Player.Dash.performed += OnRun;
        inputActions.Player.Dash.canceled += OnRun;
    }


    private void OnDisable()
    {
        inputActions.Player.Dash.canceled -= OnRun;
        inputActions.Player.Dash.performed -= OnRun;
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        onInput?.Invoke(context.ReadValue<Vector2>(), !context.canceled);
        Debug.Log(!context.canceled);
    }
    private void OnRun(InputAction.CallbackContext context)
    {
        Debug.Log("Run");
        onRun?.Invoke(context.ReadValue<float>());
    }
}
