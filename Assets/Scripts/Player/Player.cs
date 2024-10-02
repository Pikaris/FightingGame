using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 inputDirection = Vector2.zero;

    public Controller1P controller;
    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        controller = GetComponent<Controller1P>();
    }

    private void Start()
    {
        controller.onInput += OnMove;
    }

    private void FixedUpdate()
    {
        rigid.MovePosition(inputDirection * Time.fixedDeltaTime);
    }

    private void OnMove(Vector2 input, bool isPress)
    {
        if (isPress)
        {
            inputDirection = input.normalized;
        }
    }
}
