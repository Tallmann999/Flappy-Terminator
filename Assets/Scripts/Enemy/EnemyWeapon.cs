using System.Collections;
using UnityEngine;

public class EnemyWeapon : Weapon
{
    [SerializeField] private float _fireDelay = 2f;
    [SerializeField] private int _shotsCount = 3;

    private Coroutine _fireCoroutine;

    private void OnEnable()
    {
        StartAttack();
    }

    private void OnDisable()
    {
        StopAttack();
    }

    public void StartAttack()
    {
        StopAttack();
        _fireCoroutine = StartCoroutine(AttackRoutine());
    }

    public void StopAttack()
    {
        if (_fireCoroutine != null)
        {
            StopCoroutine(_fireCoroutine);
            _fireCoroutine = null;
        }
    }

    private IEnumerator AttackRoutine()
    {
        WaitForSeconds delay = new WaitForSeconds(_fireDelay);

        for (int i = 0; i < _shotsCount; i++)
        {
            yield return delay;
            Fire();
        }
    }
}