using System.Collections;
using UnityEngine;

public class EnemySpawner : SpawnerBase<Enemy>
{
    [SerializeField] private float _minSpawnHeight;
    [SerializeField] private float _maxSpawnHeight;
    //[SerializeField] private float _minSpawnDelay = 1f;
    //[SerializeField] private float _maxSpawnDelay =2f;

    //private Coroutine _current—oroutine;
    //private WaitForSeconds _waitForSeconds;

    private  void Start()
    {
        if (_current—oroutine != null)
        {
            StopCoroutine(_current—oroutine);
        }

        _current—oroutine = StartCoroutine(ObjectGenerator());
    }


    //protected override IEnumerator EnemyGenerator()
    //{
    //    _waitForSeconds = new WaitForSeconds((Random.Range(MinSpawnDelay, MaxSpawnDelay)));

    //    for (int i = 0; i < SpawnObjectCount; i++)
    //    {
    //        Enemy enemy;
    //        GreateNewPoolObject(out enemy);
    //        yield return _waitForSeconds;
    //    }
    //}

    private Vector2 GenerateRandomPosition()
    {
        float positionX = transform.position.x; 
        float positionY = Random.Range(_minSpawnHeight, _maxSpawnHeight);
        return new Vector2(positionX, positionY);
    }

    protected override void GreateNewPoolObject(out Enemy prefab)
    {
        prefab = PoolObject.GetObject();
        prefab.Destroyer -= OnReturnPoolObject;
        prefab.Destroyer += OnReturnPoolObject;
        prefab.transform.position = GenerateRandomPosition();
    }

    protected override void OnReturnPoolObject(Enemy prefab)
    {
        prefab.Destroyer += OnReturnPoolObject;
        PoolObject.ReturnPoolObject(prefab);
    }
}