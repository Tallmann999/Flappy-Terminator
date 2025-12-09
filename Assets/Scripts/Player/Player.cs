using System;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class Player : MonoBehaviour
{
    private InputReader _inputReader;
    private PlayerMover _playerMover;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _inputReader.Pressed += OnJumpPressed;

    }

    private void OnJumpPressed(bool pressed)
    {
        if (pressed)
        {
            _playerMover.Move();
        }
    }

    private void OnDisable()
    {
        _inputReader.Pressed -= OnJumpPressed;
    }
}
