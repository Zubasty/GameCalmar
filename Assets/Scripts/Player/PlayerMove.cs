using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMove : MonoBehaviour, IPersonMove
{
    [SerializeField] private float _force;
    [SerializeField] private float _maxSpeed;
    private Rigidbody _rb;
    private PlayerInput _playerInput;
    private bool _moveAllowed = true;
    public event Action GetedDamage;
    public event Action Died;
    public PlayerInput Input => _playerInput;
    public float Speed => _rb.velocity.magnitude;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();
    }
    private void OnEnable()
    {
        _playerInput.Moving += Move;
    }
    public void Move()
    {
        if(_moveAllowed)
        {
            _rb.AddForce(_force * Time.deltaTime, 0, 0);
        }
    }
    private void FixedUpdate()
    {
        if(Speed>_maxSpeed)
        {
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, _maxSpeed);
        }
    }
    public void GetDamage()
    {
        _rb.velocity = Vector3.zero;
        _moveAllowed = false;
        GetedDamage?.Invoke();
    }
    public void Destroy()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }
    private void OnDisable()
    {
        _playerInput.Moving -= Move;
    }
}
