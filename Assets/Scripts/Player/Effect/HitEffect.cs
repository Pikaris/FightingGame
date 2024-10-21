using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour, IHit
{
    ParticleSystem hitEffect;


    private void Awake()
    {
        //IHit hit = GetComponent<IHit>();
        Transform child = transform.GetChild(0);
        hitEffect = child.GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        //command = 
    }

    public void Hit()
    {
        hitEffect.Play();
    }
}
