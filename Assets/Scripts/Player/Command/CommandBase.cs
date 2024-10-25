using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBase : MonoBehaviour
{
    BoxCollider HitBoxCollider;
    BoxCollider HurtBoxCollider;

    Player player;

    public Player PlayerProp => player;

    protected virtual void Awake()
    {
        Transform child = transform.GetChild(0);
        HitBoxCollider = child.GetComponent<BoxCollider>();
        HitBoxCollider.gameObject.SetActive(false);

        child = transform.GetChild(1);
        HurtBoxCollider = child.GetComponent<BoxCollider>();
        HurtBoxCollider.gameObject.SetActive(false);

        player = GetComponentInParent<Player>();
    }

    protected virtual void Start()
    {
        player.onOnHitBox_LKick += OnHitBoxCollision;
        player.onOffHitBox_LKick += OffHitBoxCollision;
        player.onOnHurtBox_LKick += OnHurtBoxCollision;
        player.onOffHurtBox_LKick += OffHurtBoxCollision;
    }

    protected virtual void OnHitBoxCollision()
    {
        HitBoxCollider.gameObject.SetActive(true);
    }

    protected virtual void OffHitBoxCollision()
    {
        HitBoxCollider.gameObject.SetActive(false);
    }

    protected virtual void OnHurtBoxCollision()
    {
        HurtBoxCollider.gameObject.SetActive(true);
    }

    protected virtual void OffHurtBoxCollision()
    {
        HurtBoxCollider.gameObject.SetActive(false);
    }
}
