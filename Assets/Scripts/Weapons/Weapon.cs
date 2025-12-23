using System;
using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    // Сделать абстактный класс оружия  и назначить врагам одно, а игроку другое. 

    [SerializeField] protected BulletSpawner Spawner;
    [SerializeField] protected Transform FirePoint;

    protected WaitForSeconds WaitForSeconds;
    protected Coroutine CurrentCoroutine;

    protected abstract IEnumerator FireActivator();
    

    public void Shoot()
    {
        if (CurrentCoroutine != null)
        {
            StopCoroutine(FireActivator());
        }

        CurrentCoroutine = StartCoroutine(FireActivator());
    }

    //[SerializeField] private BulletSpawner _currentSpawner;
    //[SerializeField] private Transform _firePoint;


    //public void Shoot()
    //{
    //    _currentSpawner.SpawnBullet(_firePoint);
    //}
}
