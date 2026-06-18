using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private PlayerManager _playerManager;
    private RunManager _runManager;

    public event Action<string> GameEnded;

    public bool IsGameOver = false;

    private bool _hasWon;
    private bool _hasLost;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void OnEnable()
    {
        GameHub.PlayerManagerReady += OnPlayerManagerReady;
        GameHub.RunManagerReady += OnRunManagerReady;
    }

    private void OnDisable()
    {
        GameHub.PlayerManagerReady -= OnPlayerManagerReady;
        GameHub.RunManagerReady -= OnRunManagerReady;

        if (_playerManager != null)
            _playerManager.AllPlayersDied -= GameOver;

        if (_runManager != null)
            _runManager.OveredMaxTime -= GameOver;
    }

    private void OnPlayerManagerReady(PlayerManager pm)
    {
        _playerManager = pm;
        _playerManager.AllPlayersDied += GameOver;
    }

    private void OnRunManagerReady(RunManager rm)
    {
        _runManager = rm;
        _runManager.OveredMaxTime += GameOver;
    }

    public void GameOver(string reason)
    {
        IsGameOver = true;
        Debug.Log(reason);
        GameEnded?.Invoke(reason);
        Time.timeScale = 0f;
        InputManager.Instance.inputActions.Disable();
    }
}
