using UnityEngine;

public class BulletSpawner : SpawnerBase<Bullet>
{
    public Bullet SpawnBullet(Vector3 position)
    {
        Bullet bullet = CreateNewPoolObject();

        bullet.transform.position = position;
        return bullet;
    }

    protected override Bullet CreateNewPoolObject()
    {
        Bullet bullet;
        bullet = PoolObject.GetObject();
        bullet.Destroyer -= OnReturnPoolObject;
        bullet.Destroyer += OnReturnPoolObject;
        return bullet;
    }

    protected override void OnReturnPoolObject(Bullet bullet)
    {
        bullet.Destroyer -= OnReturnPoolObject;
        PoolObject.ReturnPoolObject(bullet);
    }
}