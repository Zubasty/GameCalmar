using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Enemy))]
public class EnemyAnimator : MonoBehaviour
{
    private const string KEY_LOOK = "Look";
    private Animator _animator;
    private Enemy _enemy;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();
    }
    private void OnEnable()
    {
        _enemy.SetedLook += OnSetedLook;
    }

    private void OnSetedLook(bool look)
    {
        _animator.SetBool(KEY_LOOK, look);
    }

    public void EndAnimationLook()
    {
        _enemy.StartTimer();
    }
    public void EndAnimationDontLook()
    {
        _enemy.StartTimer();
    }
}
