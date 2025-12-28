using System;
using System.Collections;
using UnityEngine;

public abstract class SpawnerBase<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T Prefab;
    [SerializeField] protected GenericObjectPool<T> PoolObject;
    [SerializeField] protected int PoolObjectCount;
    [SerializeField] protected int SpawnObjectCount;
    [SerializeField] protected float MinSpawnDelay = 1f;
    [SerializeField] protected float MaxSpawnDelay = 5f;

    protected Coroutine SpawnCoroutine;
    protected WaitForSeconds WaitDelay;

    public event Action<T> Hit;

    private void Awake()
    {
        PoolObject = new GenericObjectPool<T>(Prefab, PoolObjectCount);
    }

    public virtual void StartSpawn()
    {
        StopSpawn();
        SpawnCoroutine = StartCoroutine(SpawnRoutine());
    }

    public virtual void StopSpawn()
    {
        if (SpawnCoroutine != null)
        {
            StopCoroutine(SpawnCoroutine);
            SpawnCoroutine = null;
        }
    }

    protected abstract IEnumerator SpawnRoutine();
    protected abstract void GreateNewPoolObject(out T prefab);
    protected abstract void OnReturnPoolObject(T prefab);
    protected virtual void ResetState()
    {
        StopSpawn();
        PoolObject.ReturnAll();
    }
}