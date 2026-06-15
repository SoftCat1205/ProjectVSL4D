using System;
using UnityEngine;
using TMPro;

public class RunManager : MonoBehaviour
{
    public static RunManager Instance { get; private set; }

    public event Action<string> OveredMaxTime;

    [Header("Timer")]
    private float _currentTime;
    public TextMeshProUGUI StopWatchDisplay;
    private readonly float _maxTimeLimit = 10000;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        if (!GameManager.Instance.IsGameOver)
        {
            UpdateCurrentTime();
        }
    }

    private void UpdateCurrentTime()
    {
        _currentTime += Time.deltaTime;

        UpdateStopWatch();

        if (_currentTime >= _maxTimeLimit)
        {
            OveredMaxTime?.Invoke("Time Over");
        }
    }

    private void UpdateStopWatch()
    {
        int minutes = Mathf.FloorToInt(_currentTime / 60);
        int seconds = Mathf.FloorToInt(_currentTime % 60);

        StopWatchDisplay.text = $"{minutes:00}:{seconds:00}";
    }
}