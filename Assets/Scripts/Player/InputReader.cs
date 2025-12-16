using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private bool _isMove;
    private bool _isAttack;
    public event Action<bool> PressedMove;
    public event Action<bool> PressedAttack;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _isMove = true;
            PressedMove?.Invoke(_isMove);
        }

        if (Input.GetMouseButtonDown(0))
        {
            _isAttack = true;
            PressedAttack?.Invoke(_isMove);
        }
    }
}
