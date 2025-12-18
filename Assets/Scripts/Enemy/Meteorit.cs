using System;
using System.Collections;
using UnityEngine;

public class Meteorit : MonoBehaviour, ISpawnable<Meteorit>, IInteractable
{
    [SerializeField] private float _lifeTime = 5f;

    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;
    //private bool _isReturned;

    public event Action<Meteorit> Destroyer;

    //private void Awake()
    //{
    //    _isReturned = false;
    //}

    private void OnEnable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(LifecycleRoutine());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
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
