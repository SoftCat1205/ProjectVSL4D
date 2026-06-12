using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState
    {
        GamePlay,
        Paused,
        GameOver
    }

    public GameState currentState;
    public GameState previousState;

    [Header("UI")]
    public GameObject pauseScreen;
    public GameObject StatusScreen;
    public GameObject ResultScreen;

    public TextMeshProUGUI currentMaxHealthDisplay;
    public TextMeshProUGUI currentHealthDisplay;
    public TextMeshProUGUI currentRecoveryDisplay;
    public TextMeshProUGUI currentArmourDisplay;
    public TextMeshProUGUI currentAbilityHasteDisplay;
    public TextMeshProUGUI currentMoveSpeedDisplay;
    public TextMeshProUGUI currentVisionDisplay;

    private bool _isStatusScreenOpen = false;
    private bool _isGameOver = false;

    private int _playersAlive;


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        pauseScreen.SetActive(false);
        StatusScreen.SetActive(_isStatusScreenOpen);
        ResultScreen.SetActive(_isGameOver);
    }

    void OnEnable()
    {
        InputManager.Instance.inputActions.Player.Pause.performed += OnPause;
        InputManager.Instance.inputActions.Player.Status.performed += OnStatus;
    }

    void OnDisable()
    {
        InputManager.Instance.inputActions.Player.Pause.performed -= OnPause;
        InputManager.Instance.inputActions.Player.Status.performed -= OnStatus;
    }

    void Start()
    {
        PlayerStats[] players = FindObjectsByType<PlayerStats>(FindObjectsSortMode.None);

        _playersAlive = players.Length;
        Debug.Log(_playersAlive);

        foreach (PlayerStats player in players)
        {
            player.PlayerDied += OnPlayerDeath;
        }
    }

    void Update()
    {
        switch (currentState)
        {
            case GameState.GamePlay:

                break;
            case GameState.Paused:

                break;
            case GameState.GameOver:
                if (!_isGameOver)
                {
                    _isGameOver = true;
                    Debug.Log("UPDATE GAME OVER");
                }
                break;
            default:
                Debug.LogWarning("State Does Not Exist");
                break;
        }
    }

    public void OnStatus(InputAction.CallbackContext context)
    {
        if (currentState != GameState.GameOver)
        {
            _isStatusScreenOpen = !_isStatusScreenOpen;
            StatusScreen.SetActive(_isStatusScreenOpen);
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        switch (currentState)
        {
            case GameState.GamePlay:
                PauseGame();
                break;
            case GameState.Paused:
                ResumeGame();
                break;
            case GameState.GameOver:
                break;
            default:
                Debug.LogWarning("State Does Not Exist");
                break;
        }
    }

    public void ChangeState(GameState newState)
    {
        previousState = currentState;
        currentState = newState;
    }

    public void PauseGame()
    {
        if (currentState == GameState.GamePlay)
        {
            ChangeState(GameState.Paused);
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
            Debug.Log("Game paused");
        }
    }

    public void ResumeGame()
    {
        if (currentState == GameState.Paused)
        {
            ChangeState(GameState.GamePlay);
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
            Debug.Log("Game resumed");
        }
    }

    public void OnPlayerDeath()
    {
        _playersAlive--;
        Debug.Log("Player Died");

        if (_playersAlive <= 0f)
        {
            GameOver();

            Debug.Log(_playersAlive);
        }
    }

    public void GameOver()
    {
        ChangeState(GameState.GameOver);
        ResultScreen.SetActive(true);
        Debug.Log("GAME OVER");
        Time.timeScale = 0f;
        InputManager.Instance.inputActions.Disable();
    }
}
