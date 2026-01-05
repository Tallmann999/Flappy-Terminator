using System;
using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(PlayerAttacker))]
[RequireComponent(typeof(PlayerMover), typeof(PlayerCollisionDetector))]
public class Player : MonoBehaviour, IDamageable
{
    private PlayerCollisionDetector _playerCollisionHandler;
    private PlayerMover _playerMover;
    private PlayerAttacker _playerAttacker;
    private InputReader _inputReader;

    public event Action Died;

    private void Awake()
    {
        _playerCollisionHandler = GetComponent<PlayerCollisionDetector>();
        _inputReader = GetComponent<InputReader>();
        _playerMover = GetComponent<PlayerMover>();
        _playerAttacker = GetComponent<PlayerAttacker>();
    }

    private void OnEnable()
    {
        _inputReader.MoveInput += OnMovePressed;
        _inputReader.AttackInput += OnAttackPressed;
        _playerCollisionHandler.CollisionDetection += OnDeadlyInteraction;
    }
    private void OnDisable()
    {
        _inputReader.MoveInput -= OnMovePressed;
        _inputReader.AttackInput -= OnAttackPressed;
        _playerCollisionHandler.CollisionDetection -= OnDeadlyInteraction;
    }

    public void OnDeadlyInteraction(IInteractable interactable)
    {
        if (interactable is Ground || interactable is Enemy
            || interactable is Meteorit)
        {
            Died?.Invoke();
        }
    }

    public void TakeDamage()
    {
        Died?.Invoke();
        _playerAttacker.Reset();
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
            _playerAttacker.Attack();
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