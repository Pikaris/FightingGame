using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    readonly int Speed_Hash = Animator.StringToHash("Speed");
    readonly int Back_Hash = Animator.StringToHash("Back");
    readonly int LKick_Hash = Animator.StringToHash("L_Kick");
    readonly int LPunch_Hash = Animator.StringToHash("L_Punch");
    readonly int MPunch_Hash = Animator.StringToHash("M_Punch");
    readonly int HPunch_Hash = Animator.StringToHash("H_Punch");
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

    // LKick
    public event Action onOnHitBox_LKick;
    public event Action onOffHitBox_LKick;
    public event Action onOnHurtBox_LKick;
    public event Action onOffHurtBox_LKick;

    // LPunch
    public event Action onOnHitBox_LPunch;
    public event Action onOffHitBox_LPunch;
    public event Action onOnHurtBox_LPunch;
    public event Action onOffHurtBox_LPunch;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        Transform child = transform.GetChild(3);
        child = child.GetChild(0);
        child = child.GetChild(1);
        hurtBox = child.GetComponent<HurtBox>();


    }

    private void Start()
    {
        //hurtBox.OnHit += Hitted_Animation;
    }

    private void OnEnable()
    {
        playerInput.onInput += OnMove;
        playerInput.onRun += OnRun_Animation;
        playerInput.onLKick += OnLKick_Animation;
        playerInput.onLPunch += OnLPunch_Animation;
        playerInput.onMPunch += OnMPunch_Animation;
        playerInput.onHPunch += OnHPunch_Animation;
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

    // 공격 애니메이션 ----------------------------------------------------------------------------------------------------

    private void OnLKick_Animation()
    {
        animator.SetBool(LKick_Hash, true);
    }

    private void OnLPunch_Animation()
    {
        animator.SetBool(LPunch_Hash, true);
    }

    private void OnMPunch_Animation()
    {
        animator.SetBool(MPunch_Hash, true);
    }

    private void OnHPunch_Animation()
    {
        animator.SetBool(HPunch_Hash, true);
    }

    //---------------------------------------------------------------------------------------------------------------------------



    public void Hitted_Animation(Vector3 location, bool isHit = false)
    {
        if (isHit)
        {
            animator.SetTrigger(Hitted_Hash);
        }
    }






    // 히트 박스 관련 함수--------------------------------------------------------------------------------------------

    // LKick
    private void LKick_Box_On()
    {
        onOnHitBox_LKick?.Invoke();
        onOnHurtBox_LKick?.Invoke();
    }
    private void LKick_Box_Off()
    {
        onOffHitBox_LKick?.Invoke();
        onOffHurtBox_LKick?.Invoke();
    }

    // LPunch
    private void LPunch_Box_On()
    {
        onOnHitBox_LPunch?.Invoke();
        onOnHurtBox_LPunch?.Invoke();
    }
    private void LPunch_Box_Off()
    {
        onOffHitBox_LPunch?.Invoke();
        onOffHurtBox_LPunch?.Invoke();
    }
    //-------------------------------------------------------------------------------------------------------------------









    // 애니메이션 종료 함수-------------------------------------------------------------------------------------------------------
    private void LKick_Finish()
    {
        animator.SetBool(LKick_Hash, false);
    }
    private void LPunch_Finish()
    {
        animator.SetBool(LPunch_Hash, false);
    }
    private void MPunchFinish()
    {
        animator.SetBool(MPunch_Hash, false);
    }
    private void HPunch_Finish()
    {
        animator.SetBool(HPunch_Hash, false);
    }
}
