using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : CommandBase
{
    public event Action<Vector3, bool> OnHit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HitBox"))
        {
            Debug.Log("Hit");
            OnHit?.Invoke(other.transform.position, true);
        }
    }
}
