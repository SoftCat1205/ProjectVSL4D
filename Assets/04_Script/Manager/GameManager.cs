using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Screens")]
    public GameObject SettingScreen;
    public GameObject StatusScreen;
    public GameObject ResultScreen;

    [Header("Current Stat Displays")]
    public TextMeshProUGUI currentMaxHealthDisplay;
    public TextMeshProUGUI currentHealthDisplay;
    public TextMeshProUGUI currentRecoveryDisplay;
    public TextMeshProUGUI currentArmourDisplay;
    public TextMeshProUGUI currentAbilityHasteDisplay;
    public TextMeshProUGUI currentMoveSpeedDisplay;
    public TextMeshProUGUI currentVisionDisplay;

    [Header("Result Screen Displays")]


    [Header("Timer")]
    private float _currentTime;
    public TextMeshProUGUI StopWatchDisplay;
    private readonly float _maxTimeLimit = 10000;

    private bool _isSettingScreenOpen = false;
    private bool _isStatusScreenOpen = false;
    private bool _isGameOver = false;
    private int _playersAlive;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        SettingScreen.SetActive(_isSettingScreenOpen);
        StatusScreen.SetActive(_isStatusScreenOpen);
        ResultScreen.SetActive(_isGameOver);
    }

    private void OnEnable()
    {
        InputManager.Instance.inputActions.Player.Setting.performed += OnSetting;
        InputManager.Instance.inputActions.Player.Status.performed += OnStatus;
    }

    private void OnDisable()
    {
        InputManager.Instance.inputActions.Player.Setting.performed -= OnSetting;
        InputManager.Instance.inputActions.Player.Status.performed -= OnStatus;
    }

    private void Start()
    {
        PlayerStats[] players = FindObjectsByType<PlayerStats>(FindObjectsSortMode.None);

        _playersAlive = players.Length;
        Debug.Log("There are " + _playersAlive + " player(s) alive.");

        foreach (PlayerStats player in players)
        {
            player.PlayerLeveledUp += OnPlayerLevelUp;
            player.PlayerDied += OnPlayerDeath;
        }
    }

    private void Update()
    {
        if (!_isGameOver)
        {
            UpdateCurrentTime();
        }
    }

    public void OnStatus(InputAction.CallbackContext context)
    {
        if (!_isGameOver)
        {
            _isStatusScreenOpen = !_isStatusScreenOpen;
            StatusScreen.SetActive(_isStatusScreenOpen);
        }
    }

    public void OnSetting(InputAction.CallbackContext context)
    {
        if (!_isGameOver)
        {
            _isSettingScreenOpen = !_isSettingScreenOpen;
            SettingScreen.SetActive(_isSettingScreenOpen);
        }
    }

    public void OnPlayerLevelUp(PlayerStats playerStats)
    {

    }

    public void OnPlayerDeath()
    {
        _playersAlive--;
        Debug.Log("A Player Died");

        if (_playersAlive <= 0f)
        {
            GameOver();

            Debug.Log(_playersAlive);
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
        ResultScreen.SetActive(true);
        Debug.Log("GAME OVER");
        Time.timeScale = 0f;
        InputManager.Instance.inputActions.Disable();
    }

    private void UpdateCurrentTime()
    {
        _currentTime += Time.deltaTime;

        UpdateStopWatch();

        if (_currentTime >= _maxTimeLimit)
        {
            GameOver();
        }
    }

    private void UpdateStopWatch()
    {
        int minutes = Mathf.FloorToInt(_currentTime / 60);
        int seconds = Mathf.FloorToInt(_currentTime % 60);

        StopWatchDisplay.text = $"{minutes:00}:{seconds:00}";
    }
}
