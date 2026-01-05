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

        while (enabled)
        {
            CreateNewPoolObject();
            yield return _waitForSeconds;
        }
    }

    protected override Meteorit CreateNewPoolObject()
    {
        Meteorit meteorit = PoolObject.GetObject();
        meteorit.Destroyer += OnPoolObjectRequestedReturn;
        meteorit.transform.position = transform.position;
        return meteorit;
    }

    protected override void OnPoolObjectRequestedReturn(PoolableObject meteorit)
    {
        meteorit.Destroyer -= OnPoolObjectRequestedReturn;
        PoolObject.ReturnPoolObject((Meteorit)meteorit);
    }
}