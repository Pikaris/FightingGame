using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LKick : CommandBase
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        player.onOnHitBox_LKick += OnHitBoxCollision;
        player.onOffHitBox_LKick += OffHitBoxCollision;
        player.onOnHurtBox_LKick += OnHurtBoxCollision;
        player.onOffHurtBox_LKick += OffHurtBoxCollision;
    }

    protected override void OnHitBoxCollision()
    {
        base.OnHitBoxCollision();
    }

    protected override void OffHitBoxCollision()
    {
        base.OffHitBoxCollision();
    }

    protected override void OnHurtBoxCollision()
    {
        base.OnHurtBoxCollision();
    }

    protected override void OffHurtBoxCollision()
    {
        base.OffHurtBoxCollision();
    }






    //BoxCollider LKick_HitBoxCollider;
    //BoxCollider LKick_HurtBoxCollider;

    //Player player;

    //private void Awake()
    //{
    //    Transform child = transform.GetChild(0);
    //    LKick_HitBoxCollider = child.GetComponent<BoxCollider>();
    //    LKick_HitBoxCollider.gameObject.SetActive(false);

    //    child = transform.GetChild(1);
    //    LKick_HurtBoxCollider = child.GetComponent<BoxCollider>();
    //    LKick_HurtBoxCollider.gameObject.SetActive(false);

    //    player = GetComponentInParent<Player>();
    //}

    //private void Start()
    //{
    //    player.onOnHitBox_LKick += OnHitBoxCollision_LKick;
    //    player.onOffHitBox_LKick += OffHitBoxCollision_LKick;
    //    player.onOnHurtBox_LKick += OnHurtBoxCollision_LKick;
    //    player.onOffHurtBox_LKick += OffHurtBoxCollision_LKick;
    //}

    //private void OnHitBoxCollision_LKick()
    //{
    //    LKick_HitBoxCollider.gameObject.SetActive(true);
    //}

    //private void OffHitBoxCollision_LKick()
    //{
    //    LKick_HitBoxCollider.gameObject.SetActive(false);
    //}

    //private void OnHurtBoxCollision_LKick()
    //{
    //    LKick_HurtBoxCollider.gameObject.SetActive(true);
    //}

    //private void OffHurtBoxCollision_LKick()
    //{
    //    LKick_HurtBoxCollider.gameObject.SetActive(false);
    //}


}
