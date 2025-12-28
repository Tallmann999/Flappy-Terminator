using System.Collections.Generic;
using UnityEngine;

public class GenericObjectPool<T> where T : MonoBehaviour
{
    private T _prefab;
    private readonly Queue<T> _freeObjects = new();
    private readonly HashSet<T> _usedObjects = new();

    public GenericObjectPool(T prefab, int initializeCount)
    {
        _prefab = prefab;

        for (int i = 0; i < initializeCount; i++)
        {
            T obj = Object.Instantiate(_prefab);
            obj.gameObject.SetActive(false);
            _freeObjects.Enqueue(obj);
        }
    }

    public T GetObject()
    {
        T obj;

        if (_freeObjects.Count > 0)
        {
            obj = _freeObjects.Dequeue();
        }
        else
        {
            obj = Object.Instantiate(_prefab);
        }

        obj.gameObject.SetActive(true);
        _usedObjects.Add(obj);
        return obj;
    }

    public void ReturnPoolObject(T obj)
    {
        if (_usedObjects.Remove(obj))
        {
            obj.gameObject.SetActive(false);
            _freeObjects.Enqueue(obj);
        }
    }

    public void ReturnAll()
    {
        foreach (var obj in _usedObjects)
        {
            if (obj != null)
                obj.gameObject.SetActive(false);

            _freeObjects.Enqueue(obj);
        }

        _usedObjects.Clear();
    }
}