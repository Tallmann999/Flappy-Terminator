using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(Health))]
[RequireComponent(typeof(PlayerMover), typeof(PlayerCollisionHandler))]
public class Player : MonoBehaviour
{
    private PlayerCollisionHandler _playerCollisionHandler;
    private PlayerMover _playerMover;
    private InputReader _inputReader;
    private Health _health;


    private void OnEnable()
    {
        _inputReader.Pressed += OnMovePressed;
        _playerCollisionHandler.CollisionDetection += OnStopGame;
        _health.Die += OnDie;
    }

    private void Awake()
    {
        _playerCollisionHandler = GetComponent<PlayerCollisionHandler>();
        _inputReader = GetComponent<InputReader>();
        _playerMover = GetComponent<PlayerMover>();
        _health = GetComponent<Health>();
    }

    private void OnDisable()
    {
        _inputReader.Pressed -= OnMovePressed;
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
