using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour, IHitable
{
    public GameObject LKickEffect;
    ParticleSystem hitEffect;
    float Timer = 1.0f;

    private void Awake()
    {
        //IHit hit = GetComponent<IHit>();
        hitEffect = LKickEffect.GetComponent<ParticleSystem>();
        //hitEffect.Stop();
    }


    public void Hitted(Vector3? position)
    {
        if (hitEffect != null)
        {
            Instantiate(LKickEffect, (Vector3)position, Quaternion.identity, transform);
            StartCoroutine(EffectTimer());
            Debug.Log("IHit");
            hitEffect.Play();
        }

    }

    IEnumerator EffectTimer()
    {
        yield return new WaitForSeconds(Timer);
        if (transform.GetChild(0) != null)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
