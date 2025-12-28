using System.Collections;
using UnityEngine;

public class MeteoritSpawner : SpawnerBase<Meteorit>
{
    private WaitForSeconds _waitForSeconds;

    public void Reset()
    {
        ResetState();
    }

    protected override IEnumerator SpawnRoutine()
    {
        _waitForSeconds = new WaitForSeconds((Random.Range(MinSpawnDelay, MaxSpawnDelay)));

        for (int i = 0; i < SpawnObjectCount; i++)
        {
            GreateNewPoolObject(out Prefab);
            yield return _waitForSeconds;
        }
    }

    protected override void GreateNewPoolObject(out Meteorit meteorit)
    {
        meteorit = PoolObject.GetObject();
        meteorit.Destroyer -= OnReturnPoolObject;
        meteorit.Destroyer += OnReturnPoolObject;
        meteorit.transform.position = transform.position;
    }

    protected override void OnReturnPoolObject(Meteorit meteorit)
    {
        meteorit.Destroyer -= OnReturnPoolObject;
        PoolObject.ReturnPoolObject(meteorit);
    }

    protected override void ResetState()
    {
        base.ResetState();
    }
}