using System;
using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(Health))]
[RequireComponent(typeof(PlayerMover), typeof(PlayerCollisionHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _currentWeapon;
    private PlayerCollisionHandler _playerCollisionHandler;
    private PlayerMover _playerMover;
    private InputReader _inputReader;
    private Health _health;


    private void OnEnable()
    {
        _inputReader.PressedMove += OnMovePressed;
        _inputReader.PressedAttack += OnAttackPressed;
        _playerCollisionHandler.CollisionDetection += OnStopGame;
        _health.Die += OnDie;
    }

    private void OnAttackPressed(bool attackStatus)
    {
        if (attackStatus)
        {
            Debug.Log("Пах пах я выстрелил");
            _currentWeapon.Shoot(Vector2.right);
        }
    }

    private void Awake()
    {
        _playerCollisionHandler = GetComponent<PlayerCollisionHandler>();
        _inputReader = GetComponent<InputReader>();
        //_currentWeapon = GetComponentInChildren<Weapon>();
        _playerMover = GetComponent<PlayerMover>();
        _health = GetComponent<Health>();
    }

    private void OnDisable()
    {
        _inputReader.PressedMove -= OnMovePressed;
        _inputReader.PressedAttack -= OnAttackPressed;

        _playerCollisionHandler.CollisionDetection -= OnStopGame;
        _health.Die -= OnDie;
    }

    private void OnDie(bool deadStatus)
    {
        if (deadStatus)
        {
            Destroy(gameObject);
        }
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
}
