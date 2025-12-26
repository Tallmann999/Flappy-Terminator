using System;
using UnityEngine;

public class Game : MonoBehaviour
{
   


    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _enemySpawner;

    [SerializeField] private StartScreenGame _startScreen;
    [SerializeField] private EndScreenGame _gameOverScreen;

    private void OnEnable()
    {
        _player.GameOver += OnGameOver;
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClicked += OnRestartButtonClick;
    }

    private void OnDisable()
    {
        _player.GameOver -= OnGameOver;
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClicked -= OnRestartButtonClick;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
        _gameOverScreen.Close();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _player.Reset();
        //_enemySpawner.Reset();
    }
}
