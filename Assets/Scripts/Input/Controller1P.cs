using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller1P : MonoBehaviour
{
    PlayerInputAction inputActions;

    public Action<Vector2, bool> onInput;

    private void Awake()
    {
        inputActions = new PlayerInputAction();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMove;
    }


    private void OnDisable()
    {
        inputActions.Player.Disable();
        inputActions.Player.Move.performed -= OnMove;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        onInput?.Invoke(context.ReadValue<Vector2>(), context.started);
    }
}
