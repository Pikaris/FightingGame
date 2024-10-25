using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPunch : CommandBase
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        PlayerProp.onOnHitBox_MPunch += OnHitBoxCollision;
        PlayerProp.onOffHitBox_MPunch += OffHitBoxCollision;
        PlayerProp.onOnHurtBox_MPunch += OnHurtBoxCollision;
        PlayerProp.onOffHurtBox_MPunch += OffHurtBoxCollision;
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
