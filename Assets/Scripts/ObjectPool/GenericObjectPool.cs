using System.Collections.Generic;
using UnityEngine;

public class GenericObjectPool<T>  where T : MonoBehaviour
{
   private  T _prefab;
   private Queue<T> _pools= new Queue<T>(); 

    public GenericObjectPool(T prefab, int initializeCount)
    {
        _prefab = prefab;
        for (int i = 0; i < initializeCount; i++)
        {
            T newObject = GameObject.Instantiate(prefab, Vector3.zero,Quaternion.identity);
            newObject.gameObject.SetActive(false);
            _pools.Enqueue( newObject );
        }
    }

    //public T GetObject()
    //{
    //    T newObject;

    //    if (_pools.Count == 0)
    //    {
    //        newObject = GameObject.Instantiate(_prefab, Vector3.zero, Quaternion.identity);
    //        return newObject;
    //    }
    //    else
    //    {
    //       newObject =  _pools.Dequeue();
    //    }

    //    newObject.gameObject.SetActive(true);
    //    return newObject;
    //}
    public T GetObject()
    {
        if (_pools.Count == 0)
        {
            T obj = GameObject.Instantiate(_prefab);
            obj.gameObject.SetActive(false);
            _pools.Enqueue(obj);
        }

        T newObject = _pools.Dequeue();
        newObject.gameObject.SetActive(true);
        return newObject;
    }

    public void ReturnPoolObject(T returnObject)
    {
        _pools.Enqueue(returnObject);
        returnObject.gameObject.SetActive(false);
    }
}
