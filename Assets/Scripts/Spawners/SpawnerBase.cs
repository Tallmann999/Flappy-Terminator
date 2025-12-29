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

    public event Action<T> Hit;

    private void Awake()
    {
        PoolObject = new GenericObjectPool<T>(Prefab, PoolObjectCount);
    } 

    protected abstract T GreateNewPoolObject();
    protected abstract void OnReturnPoolObject(T prefab);
    protected virtual void ResetState()
    {
        PoolObject.ReturnAll();
    }
}