using System;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class Player : MonoBehaviour
{
    private InputReader _inputReader;
    private PlayerMover _playerMover;
    private PlayerCollisionHandler _playerCollisionHandler;

    private bool _isFly;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _playerMover = GetComponent<PlayerMover>();
        _playerCollisionHandler = GetComponent<PlayerCollisionHandler>();

    }

    private void OnEnable()
    {
        _inputReader.Pressed += OnMovePressed;
        _playerCollisionHandler.CollisionDetection += OnStopGame;

    }

    private void OnMovePressed(bool isPressed)
    {
        if (isPressed)
        {
            _playerMover.Move();
        }
    }

    public void OnStopGame(IInteractable interactable)
    {
        if (interactable is Ground)
        {
            Time.timeScale = 0;
        }
    }

    private void OnDisable()
    {
        _inputReader.Pressed -= OnMovePressed;
        _playerCollisionHandler.CollisionDetection -= OnStopGame;
    }
}
