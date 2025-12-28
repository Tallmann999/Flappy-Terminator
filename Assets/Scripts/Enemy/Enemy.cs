using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, ISpawnable<Enemy>, IInteractable, IDamageble
{
    [SerializeField] private float _lifeTime = 5f;
    [SerializeField] private Weapon _currentWeapon;
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

        _currentCoroutine = StartCoroutine(LifecycleRoutine());
    }

    public void TakeDamage()
    {
        Destroy(this);
        Died?.Invoke(this);
        ReturnToPool();
    }

    private IEnumerator LifecycleRoutine()
    {
        _waitForSeconds = new WaitForSeconds(_lifeTime);
        Shooting();
        yield return _waitForSeconds;
        ReturnToPool();
    }

    private void Shooting()
    {
        _currentWeapon.Shoot();
    }

    private void ReturnToPool()
    {
        Destroyer?.Invoke(this);
    }
}