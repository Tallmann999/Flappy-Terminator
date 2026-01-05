using UnityEngine;

public class Bullet : TimedPoolableObject, IInteractable
{
    [SerializeField] private LayerMask _damageLayers;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((_damageLayers.value & (1 << collision.gameObject.layer)) == 0)
            return;

        if (collision.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage();
            ReturnToPool();
        }
    }
}