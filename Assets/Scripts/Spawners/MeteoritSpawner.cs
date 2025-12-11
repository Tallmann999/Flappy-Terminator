using System.Collections;
using UnityEngine;

public class MeteoritSpawner : SpawnerBase<Meteorit>
{
    private Coroutine _current—oroutine;
    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        if (_current—oroutine != null)
        {
            StopCoroutine(_current—oroutine);
        }

        _current—oroutine = StartCoroutine(EnemyGenerator());
    }

    protected override IEnumerator EnemyGenerator()
    {
        _waitForSeconds = new WaitForSeconds((Random.Range(MinSpawnDelay, MaxSpawnDelay)));

        for (int i = 0; i < SpawnObjectCount; i++)
        {
            Meteorit meteorit;
            GreateNewPoolObject(out meteorit);
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
        meteorit.Destroyer += OnReturnPoolObject;
        PoolObject.ReturnPoolObject(meteorit);
    }

   
}
