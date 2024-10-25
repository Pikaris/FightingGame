using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    enum Commands
    {
        Down = 2,
        Left = 4,
        Right = 6,
        Up = 8,
        LPunch = 11,
    }

    PlayerInputAction inputActions;

    public event Action<Vector2, bool> onInput;


    // Move
    public event Action<bool> onJump;
    public event Action<bool> onDown;
    public event Action<bool> onLeft;
    public event Action<bool> onRight;

    // Attack
    public event Action onLKick;
    public event Action onLPunch;
    public event Action onMPunch;
    public event Action onHPunch;

    List<ICommandRule> commandRules;

    private void Awake()
    {
        inputActions = new PlayerInputAction();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Up.performed += OnUp;

        inputActions.Player.Down.performed += OnDownStarted;
        inputActions.Player.Down.canceled += OnDownCanceled;

        inputActions.Player.Left.performed += OnLeftStarted;
        inputActions.Player.Left.canceled += OnLeftCanceled;

        inputActions.Player.Right.performed += OnRightStarted;
        inputActions.Player.Right.canceled += OnRightCanceled;


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


        inputActions.Player.Right.canceled -= OnRightCanceled;
        inputActions.Player.Right.performed -= OnRightStarted;

        inputActions.Player.Left.canceled -= OnLeftCanceled;
        inputActions.Player.Left.performed -= OnLeftStarted;

        inputActions.Player.Down.canceled -= OnDownCanceled;
        inputActions.Player.Down.performed -= OnDownStarted;
        inputActions.Player.Up.performed -= OnUp;
        inputActions.Player.Disable();
    }

    private void OnUp(InputAction.CallbackContext context)
    {
        onJump?.Invoke(true);
    }


    // Down -------------------
    private void OnDownStarted(InputAction.CallbackContext context)
    {
        onDown?.Invoke(true);
    }

    private void OnDownCanceled(InputAction.CallbackContext context)
    {
        onDown?.Invoke(false);
    }


    // Left-------------------
    private void OnLeftStarted(InputAction.CallbackContext context)
    {
        onLeft?.Invoke(true);
    }

    private void OnLeftCanceled(InputAction.CallbackContext context)
    {
        onLeft?.Invoke(false);
    }


    // Right-------------------
    private void OnRightStarted(InputAction.CallbackContext context)
    {
        onRight?.Invoke(true);
    }

    private void OnRightCanceled(InputAction.CallbackContext context)
    {
        onRight?.Invoke(false);
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