using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LKick : MonoBehaviour
{
    BoxCollider LKick_boxCollider;
    BoxCollider LKickBody_boxCollider;

    public event Action Hitted;

    private void Awake()
    {
        Transform child = transform.GetChild(0);
        LKick_boxCollider = child.GetComponent<BoxCollider>();
        LKick_boxCollider.gameObject.SetActive(false);

        child = transform.GetChild(1);
        LKickBody_boxCollider = child.GetComponent<BoxCollider>();
    }

    private void OnCollision_LKick()
    {
        LKick_boxCollider.gameObject.SetActive(true);
    }

    private void OffCollision_LKick()
    {
        LKick_boxCollider.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == LKickBody_boxCollider)
        {
            Hitted?.Invoke();
        }
    }
}
