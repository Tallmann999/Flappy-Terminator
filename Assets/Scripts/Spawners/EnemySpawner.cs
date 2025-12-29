using System.Collections;
using UnityEngine;

public class EnemySpawner : SpawnerBase<Enemy>
{
    [SerializeField] private float _minSpawnHeight;
    [SerializeField] private float _maxSpawnHeight;
    [SerializeField] private ScoreCounter _scoreCounter;

    private WaitForSeconds _waitForSeconds;
    private Coroutine _spawnCoroutine;

    public void Reset()
    {
        ResetState();
        _scoreCounter.Reset();
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
            Enemy enemy = GreateNewPoolObject();
            yield return _waitForSeconds;
        }
    }

    protected override Enemy GreateNewPoolObject()
    {
        Enemy enemy;
        enemy = PoolObject.GetObject();
        enemy.Destroyer -= OnReturnPoolObject;
        enemy.Destroyer += OnReturnPoolObject;
        enemy.Died -= OnEnemyDied;
        enemy.Died += OnEnemyDied;
        enemy.transform.position = GenerateRandomPosition();
        return enemy;
    }

    protected override void OnReturnPoolObject(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;
        enemy.Destroyer -= OnReturnPoolObject;
        PoolObject.ReturnPoolObject(enemy);
    }

    protected override void ResetState()
    {
        base.ResetState();
    }

    private void OnEnemyDied(Enemy enemy)
    {
        _scoreCounter.Add(enemy.ScoreForKill);
    }

    private Vector2 GenerateRandomPosition()
    {
        float positionX = transform.position.x;
        float positionY = Random.Range(_minSpawnHeight, _maxSpawnHeight);
        return new Vector2(positionX, positionY);
    }
}