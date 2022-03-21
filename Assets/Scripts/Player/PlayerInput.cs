using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event Action Moving;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Moving?.Invoke();
        }
    }
}
