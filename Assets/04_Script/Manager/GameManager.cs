using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState
    {
        Gameplay,
        Paused,
        Gameover
    }

    public GameState currentState;
    public GameState previousState;

    private bool _isStatusScreenOpen = false;

    [Header("UI")]
    public GameObject pauseScreen;
    public GameObject StatusScreen;

    public TextMeshProUGUI currentMaxHealthDisplay;
    public TextMeshProUGUI currentHealthDisplay;
    public TextMeshProUGUI currentRecoveryDisplay;
    public TextMeshProUGUI currentArmourDisplay;
    public TextMeshProUGUI currentAbilityHasteDisplay;
    public TextMeshProUGUI currentMoveSpeedDisplay;
    public TextMeshProUGUI currentVisionDisplay;


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

    void Update()
    {
        switch (currentState)
        {
            case GameState.Gameplay:

                break;
            case GameState.Paused:

                break;
            case GameState.Gameover:

                break;
            default:
                Debug.LogWarning("State Does Not Exist");
                break;
        }
    }

    public void OnStatus(InputAction.CallbackContext context)
    {
        if (currentState != GameState.Gameover)
        {
            _isStatusScreenOpen = !_isStatusScreenOpen;
            StatusScreen.SetActive(_isStatusScreenOpen);
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        switch (currentState)
        {
            case GameState.Gameplay:
                PauseGame();
                break;
            case GameState.Paused:
                ResumeGame();
                break;
            case GameState.Gameover:
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
        if (currentState == GameState.Gameplay)
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
            ChangeState(GameState.Gameplay);
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
            Debug.Log("Game resumed");
        }
    }
}
