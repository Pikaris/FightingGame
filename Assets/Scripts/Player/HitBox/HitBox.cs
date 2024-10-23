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
        Transform child = effectObj.transform;
        hitEffect = effectObj.GetComponent<HitEffect>();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    IHitable hitable = other.GetComponent<IHitable>();
    //    if (hitable != null)
    //    {
    //        hitable.Hitted(null);
    //    }
    //    if (effectObj != null)
    //    {
    //        hitEffect.Hitted(other.transform.position);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("CollisionEnter");
        IHitable hitable = collision.gameObject.GetComponent<IHitable>();
        if (hitable != null)
        {
            hitable.Hitted(null);
        }
        if (effectObj != null)
        {
            hitEffect.Hitted(collision.contacts[0].point);
        }
    }
}
