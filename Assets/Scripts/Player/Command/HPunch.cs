using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPunch : CommandBase
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        PlayerProp.onOnHitBox_HPunch += OnHitBoxCollision;
        PlayerProp.onOffHitBox_HPunch += OffHitBoxCollision;
        PlayerProp.onOnHurtBox_HPunch += OnHurtBoxCollision;
        PlayerProp.onOffHurtBox_HPunch += OffHurtBoxCollision;
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
