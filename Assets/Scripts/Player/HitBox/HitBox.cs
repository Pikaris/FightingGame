using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public GameObject effectObj;
    HitEffect hitEffect;

    private void Awake()
    {
        Transform child = effectObj.transform.GetChild(0);
        hitEffect = GetComponent<HitEffect>();
    }

    private void OnTriggerEnter(Collider other)
    {
        IHitable hitable = other.GetComponent<IHitable>();
        if (hitable != null)
        {
            hitable.Hitted();
        }
        if (hitEffect != null)
        {
            hitEffect.Hitted();
        }
    }
}
