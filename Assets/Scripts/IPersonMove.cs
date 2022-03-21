using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPersonMove 
{
    public event Action GetedDamage;
    public GameObject gameObject { get; }
    public float Speed { get; }
    public void Move();
    public void GetDamage();
    public void Destroy();
}
