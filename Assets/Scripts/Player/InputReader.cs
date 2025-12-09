using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private bool _isPressed;
    public event Action<bool> Pressed;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _isPressed = true;
            Pressed?.Invoke(_isPressed);
        }
    }
}
