using System.Collections;

public class PlayerWeapon : Weapon
{
    protected override IEnumerator FireActivator()
    {
        yield return null;
        Spawner.SpawnBullet(FirePoint.position);
    }
}