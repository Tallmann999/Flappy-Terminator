using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private float _lifeTime = 5f;
    [SerializeField] private LayerMask _damageLayers;

    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;

    public event Action<Bullet> Destroyer;

    private void OnEnable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(RunLifetime());
        }

        _coroutine = StartCoroutine(RunLifetime());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(RunLifetime());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((_damageLayers.value & (1 << collision.gameObject.layer)) == 0)
            return;

        if (collision.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage();
            ReturnToPool();
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
        Destroyer?.Invoke(this);
    }
}