using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, ISpawnable<Enemy>, IInteractable,IDamageble
{
    [SerializeField] private float _lifeTime = 5f;
    //[SerializeField] private Weapon _currentWeapon;

    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;
    //private bool _isReturned;

    public event Action<Enemy> Destroyer;


    private void Start()
    {
        if(_coroutine!=null)
        {
            StopCoroutine(LifecycleRoutine());
        }

        _coroutine = StartCoroutine(LifecycleRoutine());
    }

    private IEnumerator LifecycleRoutine()
    {
        _waitForSeconds = new WaitForSeconds(_lifeTime);
        //Shooting();
        yield return _waitForSeconds;
        ReturnToPool();
    }

    //private void Shooting()
    //{
    //    while(true)
    //    {
    //        _currentWeapon.Shoot();
    //    }
    //}
    private void ReturnToPool()
    {
        Destroyer?.Invoke(this);
    }

    public void TakeDamage()
    {
        Destroy(this);
        ReturnToPool();
    }
}