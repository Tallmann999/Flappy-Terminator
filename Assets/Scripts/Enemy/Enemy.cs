using System;
using UnityEngine;

public class Enemy : TimedPoolableObject, IInteractable, IDamageable
{
    [SerializeField] private int _scoreForKill = 10;

    public event Action<Enemy> Died;

    public int ScoreForKill => _scoreForKill;

    public void TakeDamage()
    {
        Died?.Invoke(this);
        ReturnToPool();
    }
}