using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnerBase<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T Prefab;
    [SerializeField] protected GenericObjectPool<T> PoolObject;
    [SerializeField] protected int PoolObjectCount;
    [SerializeField] protected int SpawnObjectCount;
    [SerializeField] protected float MinSpawnDelay = 1f;
    [SerializeField] protected float MaxSpawnDelay = 5f;

    //[SerializeField] protected float LifeTime;

    private void Awake()
    {
        PoolObject = new GenericObjectPool<T>(Prefab, PoolObjectCount);
    }

    protected abstract IEnumerator EnemyGenerator();
    protected abstract void GreateNewPoolObject(out T prefab);
    protected abstract void OnReturnPoolObject(T prefab);
}
