using System.Collections;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _fireDelay = 2f;

    private Coroutine _attackCoroutine;
    private WaitForSeconds _delay;

    private void OnEnable()
    {
        StartAttack();
    }

    private void OnDisable()
    {
        StopAttack();
        _weapon.Reset();
    }

    private void StartAttack()
    {
        StopAttack();
        _attackCoroutine = StartCoroutine(AttackRoutine());
    }

    private void StopAttack()
    {
        if (_attackCoroutine != null)
        {
            StopCoroutine(_attackCoroutine);
            _attackCoroutine = null;
        }
    }

    private IEnumerator AttackRoutine()
    {
        _delay = new WaitForSeconds(_fireDelay);

        while (enabled)
        {
            yield return _delay;
            _weapon.Fire();
        }
    }
}