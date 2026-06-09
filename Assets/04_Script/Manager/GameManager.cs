using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Gameplay,
        Paused,
        Gameover
    }

    public GameState currentState;
    public GameState previousState;

    [Header("UI")]
    public GameObject pauseScreen;

    void Awake()
    {
        pauseScreen.SetActive(false);
    }

    void OnEnable()
    {
        InputManager.Instance.inputActions.Player.Pause.performed += OnPause;
    }

    void OnDisable()
    {
        InputManager.Instance.inputActions.Player.Pause.performed -= OnPause;
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
