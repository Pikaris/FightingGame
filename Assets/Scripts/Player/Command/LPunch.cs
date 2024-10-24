using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPunch : CommandBase
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        player.onOnHitBox_LPunch += OnHitBoxCollision;
        player.onOffHitBox_LPunch += OffHitBoxCollision;
        player.onOnHurtBox_LPunch += OnHurtBoxCollision;
        player.onOffHurtBox_LPunch += OffHurtBoxCollision;
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

}
