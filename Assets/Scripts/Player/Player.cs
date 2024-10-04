using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    const float Gravity = -0.2f;
    const float JumpForce = 20.0f;

    float speed = 3.0f;
    float currentSpeed = 0.0f;
    Vector3 direction = Vector3.zero;

    PlayerInput playerInput;
    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        playerInput.onInput += OnMove;
    }


    private void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + currentSpeed * direction * Time.fixedDeltaTime);
    }

    private void OnMove(Vector2 input, bool isPress)
    {
        if (isPress)
        {
            currentSpeed = speed;
            direction.z = input.x;
        }
        else
        {
            currentSpeed = 0.0f;
            direction = Vector3.zero;
        }
    }
}
