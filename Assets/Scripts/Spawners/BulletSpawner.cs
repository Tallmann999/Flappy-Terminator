using System.Collections;
using UnityEngine;

public class BulletSpawner : SpawnerBase<Bullet>
{  

    public void GetBulletCoroutine()
    {
        if (_current—oroutine != null)
        {
            StopCoroutine(_current—oroutine);
        }

        _current—oroutine = StartCoroutine(ObjectGenerator());
    }

    protected override IEnumerator ObjectGenerator()
    {        
        GreateNewPoolObject(out Prefab);
        yield return new WaitForSeconds(1f);
        
    }
    protected override void GreateNewPoolObject(out Bullet bullet)
    {
        bullet = PoolObject.GetObject();
        bullet.Destroyer -= OnReturnPoolObject;
        bullet.Destroyer += OnReturnPoolObject;
        bullet.transform.position = transform.position;
    }

    protected override void OnReturnPoolObject(Bullet bullet)
    {
        bullet.Destroyer += OnReturnPoolObject;
        PoolObject.ReturnPoolObject(bullet);
    }

}
