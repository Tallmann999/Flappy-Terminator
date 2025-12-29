using System.Collections;
using UnityEngine;

public class MeteoritSpawner : SpawnerBase<Meteorit>
{
    private WaitForSeconds _waitForSeconds;
    private Coroutine _spawnCoroutine;

    public void Reset()
    {
        ResetState();
    }

    public void StartSpawn()
    {
        StopSpawn();
        _spawnCoroutine = StartCoroutine(SpawnRoutine());
    }

    private void StopSpawn()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }

        ResetState();
    }

    private IEnumerator SpawnRoutine()
    {
        _waitForSeconds = new WaitForSeconds((Random.Range(MinSpawnDelay, MaxSpawnDelay)));

        for (int i = 0; i < SpawnObjectCount; i++)
        {
           CreateNewPoolObject();
            yield return _waitForSeconds;
        }
    }

    protected override Meteorit CreateNewPoolObject()
    {
        Meteorit meteorit;
        meteorit = PoolObject.GetObject();
        meteorit.Destroyer -= OnReturnPoolObject;
        meteorit.Destroyer += OnReturnPoolObject;
        meteorit.transform.position = transform.position;
        return meteorit;
    }

    protected override void OnReturnPoolObject(Meteorit meteorit)
    {
        meteorit.Destroyer -= OnReturnPoolObject;
        PoolObject.ReturnPoolObject(meteorit);
    }
}