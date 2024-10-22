using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBase : MonoBehaviour
{
    public GameObject LKick;

    HitBox hitBox;
    HurtBox hurtBox;

    private void Awake()
    {
        Transform child = LKick.transform.GetChild(0);
        hitBox = child.GetComponent<HitBox>();

        child = LKick.transform.GetChild(1);
        hurtBox = child.GetComponent<HurtBox>();
    }
}
