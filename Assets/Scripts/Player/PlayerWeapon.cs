using System.Collections;
using UnityEngine;

public class PlayerWeapon : Weapon
{
    private ScoreCounter _scoreCounter;

    //private void OnEnable()
    //{
    //    _scoreCounter.
    //}
    //private void Awake()
    //{
    //    _scoreCounter = GetComponent<ScoreCounter>();
    //}
    //private void OnDisable()
    //{
        
    //}
    protected override IEnumerator FireActivator()
    {
        yield return null;
        Spawner.SpawnBullet(FirePoint.position);

    }
}
