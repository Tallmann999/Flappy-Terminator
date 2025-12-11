using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, ISpawnable<Enemy>
{
    [SerializeField] private float _lifeTime = 5f; 

    private Health _health;
    //private EnemyMover _enemyMover;
    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;
    private bool _isReturned;

    public event Action<Enemy> Destroyer;

    private void Awake()
    {
        _isReturned = false;
        _health = GetComponent<Health>();
    }

    private void Start()
    {
        if(_coroutine!=null)
        {
            StopCoroutine(LifecycleRoutine());
        }

        _coroutine = StartCoroutine(LifecycleRoutine());
    }

    private IEnumerator LifecycleRoutine()// прописать логику жизни 
    {
        _waitForSeconds = new WaitForSeconds(_lifeTime);
        yield return _waitForSeconds;
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        if (_isReturned)
            return;

        _isReturned = true;
        Destroyer?.Invoke(this);
    }
}
