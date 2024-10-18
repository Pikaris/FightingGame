using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    readonly int Speed_Hash = Animator.StringToHash("Speed");
    readonly int Back_Hash = Animator.StringToHash("Back");
    readonly int LKick_Hash = Animator.StringToHash("L_Kick");
    readonly int Hitted_Hash = Animator.StringToHash("Hitted");
    
    const float Animator_Stop = 0.0f;
    const float Animator_Walk = 1.0f;
    const float Animator_Run = 1.8f;

    float currentSpeed = 0.0f;
    Vector3 direction = Vector3.zero;

    PlayerInput playerInput;
    Animator animator;
    Rigidbody rigid;
    HurtBox hurtBox;

    public event Action onHitLKick;
    public event Action onOnLKick;
    public event Action onOffLKick;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        Transform child = transform.GetChild(2);
        child = child.GetChild(1);
        hurtBox = child.GetComponent<HurtBox>();
    }

    private void Start()
    {
        hurtBox.onHit += Hitted_Animation;
    }

    private void OnEnable()
    {
        playerInput.onInput += OnMove;
        playerInput.onRun += OnRun_Animation;
        playerInput.onLKick += OnLKick_Animation;
    }


    private void OnDisable()
    {
        //playerInput.onRun -= OnRun;
        //playerInput.onInput -= OnMove;
    }


    private void FixedUpdate()
    {
        rigid.Move(rigid.position + currentSpeed * direction * Time.fixedDeltaTime, Quaternion.identity);
        //if()
        //Debug.Log(currentSpeed);
    }


    private void OnMove(Vector2 input, bool isPress)
    {
        if (isPress)
        {
            currentSpeed = Animator_Walk;
            direction.z = input.x;
            animator.SetFloat(Speed_Hash, Animator_Walk);
            animator.ResetTrigger(LKick_Hash);
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

    private void OnRun_Animation()
    {
        currentSpeed = Animator_Run;
        animator.SetFloat(Speed_Hash, Animator_Run);
    }
    private void OnLKick_Animation()
    {
        animator.SetTrigger(LKick_Hash);
    }

    void Hitted_Animation(bool isHit = false)
    {
        if (isHit)
        {
            animator.SetTrigger(Hitted_Hash);
        }
    }

    private void LKick_HitBox_On()
    {
        onOnLKick?.Invoke();
    }
    private void LKick_HitBox_Off()
    {
        onOffLKick?.Invoke();
    }
}
