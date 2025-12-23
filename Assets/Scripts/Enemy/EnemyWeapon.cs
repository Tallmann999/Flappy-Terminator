using System.Collections;
using UnityEngine;

public class EnemyWeapon : Weapon
{
    [SerializeField] private float _delaySpawnBullet = 2f;

    private void Awake()
    {
        WaitForSeconds = new WaitForSeconds(_delaySpawnBullet);
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