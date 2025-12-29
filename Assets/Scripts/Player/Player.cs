using System;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(PlayerMover), typeof(PlayerCollisionDetector))]
public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerWeapon _currentWeapon;

    private PlayerCollisionDetector _playerCollisionHandler;
    private PlayerMover _playerMover;
    private InputReader _inputReader;

    public event Action GameOver;

    private void OnEnable()
    {
        _inputReader.PressedMove += OnMovePressed;
        _inputReader.PressedAttack += OnAttackPressed;
       _playerCollisionHandler.CollisionDetection += OnStopGame;
    }

    private void Awake()
    {
        _playerCollisionHandler = GetComponent<PlayerCollisionDetector>();
        _inputReader = GetComponent<InputReader>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnDisable()
    {
        _inputReader.PressedMove -= OnMovePressed;
        _inputReader.PressedAttack -= OnAttackPressed;
        _playerCollisionHandler.CollisionDetection -= OnStopGame;
    }

    public void OnStopGame(IInteractable interactable)
    {
        if (interactable is Ground || interactable is Enemy
            || interactable is Meteorit)
        {
            GameOver?.Invoke();
        }
    }

    public void TakeDamage()
    {
        GameOver?.Invoke();
        Time.timeScale = 0;
    }

    public void Reset()
    {
        _playerMover.Reset();
    }

    private void OnAttackPressed(bool canAttack)
    {
        if (canAttack)
        {
            _currentWeapon.Shoot();
        }
    }

    private void OnMovePressed(bool isPressed)
    {
        if (isPressed)
        {
            _playerMover.Move();
        }
    }
}