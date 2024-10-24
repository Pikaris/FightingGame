using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerInputAction inputActions;

    public event Action<Vector2, bool> onInput;
    public event Action onRun;
    public event Action<float> onJump;
    public event Action onLKick;
    public event Action onLPunch;
    public event Action onMPunch;
    public event Action onHPunch;

    private void Awake()
    {
        inputActions = new PlayerInputAction();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
        inputActions.Player.Dash.started += OnRun;
        //inputActions.Player.Dash.canceled += OnRun;
        inputActions.Player.LKick.performed += OnLKick;
        inputActions.Player.LPunch.performed += OnLPunch;
        inputActions.Player.MPunch.performed += OnMPunch;
        inputActions.Player.HPunch.performed += OnHPunch;
    }


    private void OnDisable()
    {
        inputActions.Player.HPunch.performed += OnHPunch;
        inputActions.Player.MPunch.performed += OnMPunch;
        inputActions.Player.LPunch.performed += OnLPunch;
        inputActions.Player.LKick.performed -= OnLKick;
        //inputActions.Player.Dash.canceled -= OnRun;
        inputActions.Player.Dash.started -= OnRun;
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        onInput?.Invoke(context.ReadValue<Vector2>(), !context.canceled);
        Debug.Log("OnMove");
    }

    private void OnRun(InputAction.CallbackContext context)
    {
        onRun?.Invoke();
    }

    private void OnLKick(InputAction.CallbackContext context)
    {
        onLKick?.Invoke();
    }

    private void OnLPunch(InputAction.CallbackContext context)
    {
        onLPunch?.Invoke();
    }

    private void OnMPunch(InputAction.CallbackContext context)
    {
        onMPunch?.Invoke();
    }

    private void OnHPunch(InputAction.CallbackContext context)
    {
        onHPunch?.Invoke();
    }
}