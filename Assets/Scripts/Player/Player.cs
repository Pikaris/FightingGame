using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    readonly int Walk_Hash = Animator.StringToHash("Speed");
    const float Animator_Stop = 0.0f;
    const float Animator_Walk = 0.5f;

    float speed = 3.0f;
    float currentSpeed = 0.0f;
    Vector3 direction = Vector3.zero;

    PlayerInput playerInput;
    Animator animator;
    Rigidbody rigid;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        playerInput.onInput += OnMove;
    }


    private void FixedUpdate()
    {
        rigid.Move(rigid.position + currentSpeed * direction * Time.fixedDeltaTime, Quaternion.identity);
        Debug.Log(currentSpeed);
    }

    private void OnMove(Vector2 input, bool isPress)
    {
        if (isPress)
        {
            currentSpeed = Animator_Walk;
            direction.z = input.x;
            animator.SetFloat(Walk_Hash, Animator_Walk);
        }
        else
        {
            currentSpeed = Animator_Stop;
            direction = Vector3.zero;
            animator.SetFloat(Walk_Hash, Animator_Stop);
        }
    }
}
