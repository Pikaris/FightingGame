using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    readonly int Speed_Hash = Animator.StringToHash("Speed");
    readonly int Back_Hash = Animator.StringToHash("Back");
    
    const float Animator_Stop = 0.0f;
    const float Animator_Walk = 1.0f;
    const float Animator_Run = 1.8f;

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
        playerInput.onRun += OnRun;
    }


    private void FixedUpdate()
    {
        rigid.Move(rigid.position + currentSpeed * direction * Time.fixedDeltaTime, Quaternion.identity);
        //Debug.Log(currentSpeed);
    }

    private void OnMove(Vector2 input, bool isPress)
    {
        if (isPress)
        {
            currentSpeed = Animator_Walk;
            direction.z = input.x;
            animator.SetFloat(Speed_Hash, Animator_Walk);
            if (direction.z < 0.0f)
            {
                animator.SetBool(Back_Hash, true);
            }
            else
            {
                animator.SetBool(Back_Hash, false);
            }
        }
        else
        {
            currentSpeed = Animator_Stop;
            direction = Vector3.zero;
            animator.SetFloat(Speed_Hash, Animator_Stop);
        }
    }

    private void OnRun(float input)
    {
        currentSpeed = Animator_Run;
        direction.z = input;
        animator.SetFloat(Speed_Hash, Animator_Run);
    }
}
