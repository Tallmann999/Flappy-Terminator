using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform firePoint;

    public void Shoot(Vector2 direction)
    {
        Bullet bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            Quaternion.identity
        );

        bullet.Init(direction.normalized);
    }

    ////[SerializeField] private BulletSpawner _currentSpawner;
    //[SerializeField] private Bullet bullet;

    ////private void Awake()
    ////{
    ////    _currentSpawner = GetComponent<BulletSpawner>();
    ////}

    //public void Shoot()
    //{
    //    //_currentSpawner.GetBulletCoroutine();
    //    Bullet newbullet = Instantiate(bullet,transform.position,Quaternion.identity);
    //}
}
