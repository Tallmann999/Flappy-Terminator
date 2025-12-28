using System;
using System.Collections;
using UnityEngine;

public class Meteorit : MonoBehaviour, ISpawnable<Meteorit>, IInteractable
{
    [SerializeField] private float _lifeTime = 2f;

    private WaitForSeconds _waitForSeconds;
    private Coroutine _currentCoroutine;

    public event Action<Meteorit> Destroyer;

    private void OnEnable()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(LifecycleRoutine());
        }

        _currentCoroutine = StartCoroutine(LifecycleRoutine());
    }

    private void OnDisable()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(LifecycleRoutine());
        }
    }

    private IEnumerator LifecycleRoutine()
    {
        _waitForSeconds = new WaitForSeconds(_lifeTime);
        yield return _waitForSeconds;
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        //if (_isReturned)
        //    return;

        //_isReturned = true;
        Destroyer?.Invoke(this);
    }
}
