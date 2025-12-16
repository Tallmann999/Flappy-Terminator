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
    protected Coroutine _current—oroutine;
    protected WaitForSeconds _waitForSeconds;

    //protected virtual void Start()
    //{
    //    if (_current—oroutine != null)
    //    {
    //        StopCoroutine(_current—oroutine);
    //    }

    //    _current—oroutine = StartCoroutine(ObjectGenerator());
    //}

    private void Awake()
    {
        PoolObject = new GenericObjectPool<T>(Prefab, PoolObjectCount);
    }

    protected virtual  IEnumerator ObjectGenerator( )
    {
        _waitForSeconds = new WaitForSeconds((Random.Range(MinSpawnDelay, MaxSpawnDelay)));

        for (int i = 0; i < SpawnObjectCount; i++)
        {
            //Enemy enemy;
            GreateNewPoolObject(out Prefab);
            yield return _waitForSeconds;
        }
    }
    protected abstract void GreateNewPoolObject(out T prefab);
    protected abstract void OnReturnPoolObject(T prefab);
}
