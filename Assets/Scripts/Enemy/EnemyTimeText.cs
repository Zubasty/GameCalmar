using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Enemy))]
public class EnemyTimeText : MonoBehaviour
{
    private Enemy _enemy;
    [SerializeField] private Text _text;
    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }
    private void OnEnable()
    {
        _enemy.SetedLook += OnSetLook;
    }
    private void Update()
    {
        _text.text = _enemy.Timer.ToString("0.00");
    }
    private void OnSetLook(bool look)
    {
        _text.color = look ? Color.red : Color.green;
    }
    private void OnDisable()
    {
        _enemy.SetedLook -= OnSetLook;
    }
}