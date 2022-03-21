using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class PlayerFinish : MonoBehaviour
{
    public event Action Finished; 
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Finish finish))
        {
            Finished?.Invoke();
        }
    }
}
