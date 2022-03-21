using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(IPersonMove))]
public class PlayerAnimator : MonoBehaviour
{
    private const string KEY_SPEED = "Speed";
    private const string KEY_DIE = "Die";
    private Animator _animator;
    private IPersonMove _personMove;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _personMove = GetComponent<IPersonMove>();
    }
    private void OnEnable()
    {
        _personMove.GetedDamage += () => _animator.SetTrigger(KEY_DIE);
    }
    private void Update()
    {
        _animator.SetFloat(KEY_SPEED, _personMove.Speed);
    }
    private void OnDisable()
    {
        _personMove.GetedDamage -= () => _animator.SetTrigger(KEY_DIE);
    }
}
