using System;
using UnityEngine;

public interface IHitable
{
    void Hitted(Vector3? position);
}