using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode _moveKey = KeyCode.Space;
    [SerializeField] private KeyCode _attackKey = KeyCode.Mouse0;

    private bool _isMove;
    private bool _isAttack;

    public event Action<bool> MoveInput;
    public event Action<bool> AttackInput;

    private void FixedUpdate()
    {
        if (Input.GetKey(_moveKey))
        {
            _isMove = true;
            MoveInput?.Invoke(_isMove);
        }

        if (Input.GetKeyDown(_attackKey))
        {
            _isAttack = true;
            AttackInput?.Invoke(_isAttack);
        }
    }
}