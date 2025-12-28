using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode Move = KeyCode.Space;

    private bool _isMove;
    private bool _isAttack;

    public event Action<bool> PressedMove;
    public event Action<bool> PressedAttack;

    private void FixedUpdate()
    {
        if (Input.GetKey(Move))
        {
            _isMove = true;
            PressedMove?.Invoke(_isMove);
        }

        if (Input.GetMouseButtonDown(0))
        {
            _isAttack = true;
            PressedAttack?.Invoke(_isAttack);
        }
    }
}