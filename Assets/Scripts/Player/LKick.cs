using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LKick : MonoBehaviour
{
    BoxCollider LKick_boxCollider;
    BoxCollider LKickBody_boxCollider;

    public event Action<bool> onHitted;

    private void Awake()
    {
        Transform child = transform.GetChild(0);
        LKick_boxCollider = child.GetComponent<BoxCollider>();
        LKick_boxCollider.gameObject.SetActive(false);

        child = transform.GetChild(1);
        LKickBody_boxCollider = child.GetComponent<BoxCollider>();
    }

    private void Start()
    {
        onHitted?.Invoke(false);
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
        if(collision.gameObject.CompareTag("Hitted"))
        {
            Debug.Log("Hit");
            onHitted?.Invoke(true);
        }
    }
}
