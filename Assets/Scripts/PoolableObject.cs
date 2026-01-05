using System;
using UnityEngine;

public abstract class PoolableObject : MonoBehaviour
{
    public event Action<PoolableObject> Destroyer;

    protected void ReturnToPool()
    {
        Destroyer?.Invoke(this);
    }
}
