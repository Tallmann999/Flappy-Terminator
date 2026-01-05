using UnityEngine;

public abstract class SpawnerBase<T> : MonoBehaviour where T : PoolableObject
{
    [SerializeField] protected T Prefab;
    [SerializeField] protected ObjectPool<T> PoolObject;
    [SerializeField] protected int PoolObjectCount;
    [SerializeField] protected int SpawnObjectCount;
    [SerializeField] protected float MinSpawnDelay = 1f;
    [SerializeField] protected float MaxSpawnDelay = 5f;

    private void Awake()
    {
        PoolObject = new ObjectPool<T>(Prefab, PoolObjectCount);
    } 

    protected abstract T CreateNewPoolObject();
    protected abstract void OnPoolObjectRequestedReturn(PoolableObject prefab);
    protected virtual void ResetState()
    {
        PoolObject.ReturnAll();
    }
}