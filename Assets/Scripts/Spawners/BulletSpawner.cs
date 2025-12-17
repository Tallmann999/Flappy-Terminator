using System;
using System.Collections;
using UnityEngine;

public class BulletSpawner : SpawnerBase<Bullet>
{
    protected override void GreateNewPoolObject(out Bullet bullet)
    {
        bullet = PoolObject.GetObject();
        bullet.Destroyer -= OnReturnPoolObject;
        bullet.Destroyer += OnReturnPoolObject;
        bullet.transform.position = transform.position;
    }

    protected override void OnReturnPoolObject(Bullet bullet)
    {
        bullet.Destroyer -= OnReturnPoolObject;
        PoolObject.ReturnPoolObject(bullet);
    }

    public void SpawnBullet()
    {
        GreateNewPoolObject(out Prefab);
    }       

}
