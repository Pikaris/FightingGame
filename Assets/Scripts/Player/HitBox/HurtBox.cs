using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public event Action<bool> onHit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HitBox"))
        {
            Debug.Log("Hit");
            onHit?.Invoke(true);
        }
    }
}
