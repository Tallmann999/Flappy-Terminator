using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Сделать абстактный класс оружия  и назначить врагам одно, а игроку другое. 

    [SerializeField] private BulletSpawner _spawner;
    [SerializeField] private Transform _firePoint;

    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;

    

    private IEnumerator FireActivator()
    {
        yield return null;
        _spawner.SpawnBullet(_firePoint.position);
       
    }

    public void Shoot()
    {
        StartCoroutine(FireActivator());
    }

    //[SerializeField] private BulletSpawner _currentSpawner;
    //[SerializeField] private Transform _firePoint;


    //public void Shoot()
    //{
    //    _currentSpawner.SpawnBullet(_firePoint);
    //}
}
