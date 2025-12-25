using UnityEngine;

public class BulletSpawner : SpawnerBase<Bullet>
{
    //[SerializeField] protected float MinSpawnDelay = 1f; Это для задердки между выстрелами регулировать
    //[SerializeField] protected float MaxSpawnDelay = 5f;


    [SerializeField] private BulletOwner _owner;
    public int CurrentSpawnCount => SpawnObjectCount;
   
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

    public Bullet SpawnBullet(Vector3 position)
    {
        Bullet bullet;
        GreateNewPoolObject(out bullet);
        bullet.transform.position = position;
        return bullet;
    }
    protected override void Reset()
    {
        // Реализовать остановку спавна
    }
}
