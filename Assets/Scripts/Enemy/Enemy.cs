using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IInteractable, IDamageable
{
    [SerializeField] private float _lifeTime = 5f;
    [SerializeField] private EnemyWeapon _currentWeapon;
    [SerializeField] private int _scoreForKill = 10;

    private WaitForSeconds _waitForSeconds;
    private Coroutine _currentCoroutine;

    public event Action<Enemy> Died;
    public event Action<Enemy> Destroyer;

    public int ScoreForKill => _scoreForKill;

    private void Start()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(RunLifetime());
    }

    public void TakeDamage()
    {
        Died?.Invoke(this);
        ReturnToPool();
    }

    private IEnumerator RunLifetime()
    {
        _waitForSeconds = new WaitForSeconds(_lifeTime);
        yield return _waitForSeconds;
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        Destroyer?.Invoke(this);
    }
}