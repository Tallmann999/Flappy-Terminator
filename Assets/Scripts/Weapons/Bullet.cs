using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour, ISpawnable<Bullet>, IInteractable
{
    [SerializeField] private float _lifeTime = 5f;
    //[SerializeField] private int _damage = 5;

    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;

    public event Action<Bullet> Destroyer;


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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageble idamageble))
        {
            idamageble.TakeDamage();
            ReturnToPool();
        }
    }
   
    private void ReturnToPool()
    {
        ////if (_isReturned)
        ////    return;

        //_isReturned = true;
        Destroyer?.Invoke(this);
    }
}
