using System;
using UnityEngine;

public class EnemyBullet : Bullet, ISpawnable<Bullet>, IInteractable
{
    public event Action<Bullet> Destroyer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
   

        if (Owner == BulletOwner.Enemy && collision.TryGetComponent(out Player player))
        {
            player.TakeDamage();
            ReturnToPool();
        }
    }

    private void ReturnToPool()
    {
        ////if (_isReturned)
        ////    return;

        //_isReturned = true;
        Destroyer?.Invoke(this);
    }
}
