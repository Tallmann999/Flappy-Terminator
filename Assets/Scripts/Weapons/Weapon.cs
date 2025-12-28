using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected BulletSpawner Spawner;
    [SerializeField] protected Transform FirePoint;

    protected WaitForSeconds WaitForSeconds;
    protected Coroutine CurrentCoroutine;

    protected abstract IEnumerator FireActivator();

    public void Shoot()
    {
        if (CurrentCoroutine != null)
        {
            StopCoroutine(FireActivator());
        }

        CurrentCoroutine = StartCoroutine(FireActivator());
    }
}