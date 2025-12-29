using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected BulletSpawner Spawner;
    [SerializeField] protected Transform FirePoint;

    protected void Fire()
    {
        Spawner.SpawnBullet(FirePoint.position);
    }
}