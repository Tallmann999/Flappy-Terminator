using System.Collections;
using UnityEngine;

public class EnemyWeapon : Weapon
{
    [SerializeField] private float _maxDelaySpawnBullet = 2f;

    private void Awake()
    {
        WaitForSeconds = new WaitForSeconds(_maxDelaySpawnBullet);
    }

    protected override IEnumerator FireActivator()
    {
        for (int i = 0; i < Spawner.CurrentSpawnCount; i++)
        {
            yield return WaitForSeconds;
            Spawner.SpawnBullet(FirePoint.position);
        }
    }
}