using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBase : MonoBehaviour
{
    HitBox hitBox;
    HurtBox hurtBox;

    private void Awake()
    {
        Transform child = transform.GetChild(0);
        hitBox = child.GetComponent<HitBox>();

        child = transform.GetChild(1);
        hurtBox = child.GetComponent<HurtBox>();
    }
}
