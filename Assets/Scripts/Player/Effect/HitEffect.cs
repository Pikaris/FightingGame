using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour, IHitable
{
    ParticleSystem hitEffect;


    private void Awake()
    {
        //IHit hit = GetComponent<IHit>();
        Transform child = transform.GetChild(0);
        hitEffect = child.GetComponent<ParticleSystem>();
        //hitEffect.Stop();
    }

    public void Hitted()
    {
        Instantiate(hitEffect);
        Debug.Log("IHit");
        //hitEffect.Play();
    }
}
