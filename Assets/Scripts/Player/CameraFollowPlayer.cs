using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Vector3 _offset;
    private void Awake()
    {
        _offset = transform.position - _target.position;
    }
    private void Update()
    {
        if(_target)
        {
            transform.position = _target.position + _offset;
        }
    }
}
