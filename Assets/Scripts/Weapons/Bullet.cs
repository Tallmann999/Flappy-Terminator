using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour, ISpawnable<Bullet>, IInteractable
{
    [SerializeField] private float _lifeTime = 5f;

    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;

    public event Action<Bullet> Destroyer;

    public BulletOwner Owner { get; private set; }

    private void OnEnable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(LifecycleRoutine());
        }

        _coroutine = StartCoroutine(LifecycleRoutine());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(LifecycleRoutine());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (Owner == BulletOwner.Player && collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage();
            ReturnToPool();
        }

        if (Owner == BulletOwner.Enemy && collision.TryGetComponent(out Player player))
        {
            player.TakeDamage();
            ReturnToPool();
        }
    }

    public void Init(BulletOwner owner)
    {
        Owner = owner;
    }

    private IEnumerator LifecycleRoutine()
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