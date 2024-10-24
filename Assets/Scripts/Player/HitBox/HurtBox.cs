using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour, IHitable
{
    //public event Action<Vector3, bool> OnHit;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("HitBox"))
    //    {
    //        Debug.Log("Hit");
    //        OnHit?.Invoke(other.transform.position, true);
    //    }
    //}
    Player player;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }

    public void Hitted(Vector3? position)
    {
        player.Hitted_Animation((Vector3)position, true);
    }
}
