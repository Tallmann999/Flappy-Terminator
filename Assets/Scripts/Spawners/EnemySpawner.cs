using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : SpawnerBase<Enemy>
{
    [SerializeField] private float _minSpawnHeight;
    [SerializeField] private float _maxSpawnHeight;

    private WaitForSeconds _waitForSeconds;
    private Coroutine _spawnCoroutine;

    public event Action<Enemy> EnemyDespawned;

    public void Reset()
    {
        ResetState();
    }

    public void StartSpawn()
    {
        StopSpawn();
        _spawnCoroutine = StartCoroutine(SpawnRoutine());
    }

    protected override Enemy CreateNewPoolObject()
    {

        Enemy enemy = PoolObject.GetObject();
        enemy.Destroyer += OnPoolObjectRequestedReturn;
        enemy.Died += OnEnemyDied;
        enemy.transform.position = GenerateRandomPosition();
        return enemy;
    }

    protected override void OnPoolObjectRequestedReturn(PoolableObject obj)
    {
        Enemy enemy = (Enemy)obj;
        enemy.Died -= OnEnemyDied;
        obj.Destroyer -= OnPoolObjectRequestedReturn;
        PoolObject.ReturnPoolObject((Enemy)obj);
    }

    private void OnEnemyDied(Enemy enemy)
    {
        EnemyDespawned?.Invoke(enemy);
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
        _waitForSeconds = new WaitForSeconds((UnityEngine.Random.Range(MinSpawnDelay, MaxSpawnDelay)));

        while (enabled)
        {
            CreateNewPoolObject();
            yield return _waitForSeconds;
        }
    }

    private Vector2 GenerateRandomPosition()
    {
        float positionX = transform.position.x;
        float positionY = UnityEngine.Random.Range(_minSpawnHeight, _maxSpawnHeight);
        return new Vector2(positionX, positionY);
    }
}