using System;
using System.Collections;
using UnityEngine;

public class Meteorit : MonoBehaviour, IInteractable
{
    [SerializeField] private float _lifeTime = 2f;

    private WaitForSeconds _waitForSeconds;
    private Coroutine _currentCoroutine;

    public event Action<Meteorit> Destroyer;

    private void OnEnable()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(RunLifetime());
        }

        _currentCoroutine = StartCoroutine(RunLifetime());
    }

    private void OnDisable()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(RunLifetime());
        }
    }

    private IEnumerator RunLifetime()
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
