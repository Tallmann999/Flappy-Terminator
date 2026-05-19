using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private BulletSpawner _spawner;
    [SerializeField] private Transform _firePoint;

    private float _bulletSpeedMultiplier = 1f;

    public void Fire()
    {
        Bullet bullet = _spawner.SpawnBullet(_firePoint.position);
        BulletMover mover = bullet.GetComponent<BulletMover>();
        mover.SetSpeedMultiplier(_bulletSpeedMultiplier);
        mover.SetDirection(_firePoint.right);
    }

    public void SetBulletSpeedMultiplier(float multiplier)
    {
        _bulletSpeedMultiplier = Mathf.Max(0f, multiplier);
    }

    public void Reset()
    {
        SetBulletSpeedMultiplier(1f);
        _spawner.ResetSpawner();
    }
}
