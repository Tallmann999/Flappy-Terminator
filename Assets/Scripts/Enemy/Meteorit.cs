using System;
using System.Collections;
using UnityEngine;

public class Meteorit : MonoBehaviour, ISpawnable<Meteorit>, IInteractable
{
    [SerializeField] private float _lifeTime = 5f;

    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;
    private bool _isReturned;

    public event Action<Meteorit> Destroyer;


    private void Awake()
    {
        _isReturned = false;
    }

    private void Start()
    {
        if (_coroutine != null)
        {
            StopCoroutine(LifecycleRoutine());
        }

        _coroutine = StartCoroutine(LifecycleRoutine());
    }

    private IEnumerator LifecycleRoutine()
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
