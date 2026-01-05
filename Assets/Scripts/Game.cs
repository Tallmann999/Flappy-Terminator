using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private MeteoritSpawner _meteoritSpawner;
    [SerializeField] private AudioSource _mainLevelMusic;
    [SerializeField] private StartScreenGame _startScreen;
    [SerializeField] private EndScreenGame _gameOverScreen;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void Awake()
    {
        _mainLevelMusic.Stop();
    }

    private void OnEnable()
    {
        _player.Died += OnGameOver;
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClicked += OnRestartButtonClick;
        _enemySpawner.EnemyDespawned += OnEnemyDespawned;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
        _gameOverScreen.Close();
    }

    private void OnDisable()
    {
        _player.Died -= OnGameOver;
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClicked -= OnRestartButtonClick;
        _enemySpawner.EnemyDespawned -= OnEnemyDespawned;
    }

    private void OnEnemyDespawned(Enemy enemy)
    {
        _scoreCounter.Add(enemy.ScoreForKill);
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _mainLevelMusic.Stop();
        _gameOverScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        _meteoritSpawner.StartSpawn();
        _enemySpawner.StartSpawn();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        _mainLevelMusic.Play();
        Time.timeScale = 1;

        _player.Reset();
        _enemySpawner.Reset();
        _meteoritSpawner.Reset();
        _scoreCounter.Reset();

        _enemySpawner.StartSpawn();
        _meteoritSpawner.StartSpawn();
    }
}