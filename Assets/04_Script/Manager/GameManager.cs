using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Screens")]
    [SerializeField] private ResultScreenController ResultScreen;

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
        PlayerManager.Instance.AllPlayersDied += GameOver;
        RunManager.Instance.OveredMaxTime += GameOver;
    }

    private void OnDisable()
    {
        PlayerManager.Instance.AllPlayersDied -= GameOver;
        RunManager.Instance.OveredMaxTime -= GameOver;
    }

    public void GameOver(string reason)
    {
        IsGameOver = true;
        Debug.Log(reason);
        ResultScreen.Show();
        Time.timeScale = 0f;
        InputManager.Instance.inputActions.Disable();
    }
}
