using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private List<IPersonMove> _personsMove = new List<IPersonMove>();
    [SerializeField] private float _timeMinDontLook;
    [SerializeField] private float _timeMaxDontLook;
    [SerializeField] private float _timeMinLook;
    [SerializeField] private float _timeMaxLook;
    [SerializeField] private EnemyEye _enemyEye;
    public event Action<bool> SetedLook;
    private bool _tickingTimer = true;
    private bool _look = false;
    private float _timer;
    public bool Look => _look;
    public float Timer => _timer;
    private float TimeDontLook => UnityEngine.Random.Range(_timeMinDontLook, _timeMaxDontLook);
    private float TimeLook => UnityEngine.Random.Range(_timeMinLook, _timeMaxLook);
    private void Awake()
    {
        GameObject[] gameObjects = FindObjectsOfType<GameObject>().Where(o => o.TryGetComponent(out IPersonMove personMove)).ToArray();
        foreach(GameObject go in gameObjects)
        {
            _personsMove.Add(go.GetComponent<IPersonMove>());
        }
        _timer = TimeDontLook;
    }
    private void Update()
    {
        if(_tickingTimer)
        {
            _timer -= Time.deltaTime;
            if (_look)
            {
                FindMovingPlayers();
                EndEpisodeLook();
            }
            else
            {
                EndEpisodeLook();
            }
        }     
    }
    private void FindMovingPlayers()
    {
        for(int i = 0; i< _personsMove.Count; i++)
        {
            if(_personsMove[i].Speed>1)
            {
                _enemyEye.Attack(_personsMove[i]);
                _personsMove.Remove(_personsMove[i]);
            }
        }
    }
    private bool EndEpisodeLook()
    {
        if(_timer <= 0)
        {
            _tickingTimer = false;
            _look = !_look;
            _timer = _look ? TimeLook : TimeDontLook;
            SetedLook?.Invoke(_look);
            return true;
        }
        return false;
    }
    public void StartTimer()
    {
        _tickingTimer = true;
    }
}