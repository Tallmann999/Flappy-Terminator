using System.Collections;
using UnityEngine;

public class BulletSpawner : SpawnerBase<Bullet>
{
    [SerializeField] private BulletOwner _owner;

    public int CurrentSpawnCount => SpawnObjectCount;

    public Bullet SpawnBullet(Vector3 position)
    {
        Bullet bullet;
        GreateNewPoolObject(out bullet);
        bullet.transform.position = position;
        return bullet;
    }

    protected override void GreateNewPoolObject(out Bullet bullet)
    {
        bullet = PoolObject.GetObject();
        bullet.Destroyer -= OnReturnPoolObject;
        bullet.Destroyer += OnReturnPoolObject;
        bullet.Init(_owner);
    }

    protected override void OnReturnPoolObject(Bullet bullet)
    {
        bullet.Destroyer -= OnReturnPoolObject;
        PoolObject.ReturnPoolObject(bullet);
    }

    protected override void ResetState()
    {
        base.ResetState();
    }

    protected override IEnumerator SpawnRoutine()
    {
        yield return null;
    }
}