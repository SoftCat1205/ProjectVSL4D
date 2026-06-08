using UnityEngine;

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

    void Update() 
    {
        switch(currentState)
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

    public void ChangeState(GameState newState)
    {
        previousState = currentState;
        currentState = newState;
    }

    public void PauseGame()
    {
        if(currentState == GameState.Gameplay)
        {
            ChangeState(GameState.Paused);
            Time.timeScale = 0f;
            Debug.Log("Game is paused");
        }
    }

    public void ResumeGame()
    {
        if(currentState == GameState.Paused)
        {
            ChangeState(GameState.Gameplay);
            Time.timeScale = 1f;
            Debug.Log("Game is paused");
        }
    }

    public void OnPause()
    {
        Debug.Log("Escape key detected");
    }
}
