using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private BulletSpawner _currentSpawner;

    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;

    private IEnumerator Shooting(float timer)
    {
        _waitForSeconds = new WaitForSeconds(timer);
        yield return _waitForSeconds;
    }

    public void Shoot()
    {
        _currentSpawner.SpawnBullet();
    }
}
