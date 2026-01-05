using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private BulletSpawner _spawner;
    [SerializeField] private Transform _firePoint;

    public void Fire()
    {
        Bullet bullet = _spawner.SpawnBullet(_firePoint.position);
        BulletMover mover = bullet.GetComponent<BulletMover>();
        mover.SetDirection(_firePoint.right);
    }

    public void Reset()
    {
        _spawner.ResetSpawner();
    }
}