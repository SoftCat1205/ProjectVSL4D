using UnityEngine;
using TMPro;
using System;

public class ResultScreenController : MonoBehaviour
{
    //Reference
    [SerializeField] private GameObject ResultScreen;
    [SerializeField] private TextMeshProUGUI Reason;

    //Result Info

    //Private Variables
    private void Awake()
    {
        Hide();
    }

    private void OnEnable()
    {
        GameManager.Instance.GameEnded += OnGameEnd;
    }

    private void OnDisable()
    {
        GameManager.Instance.GameEnded -= OnGameEnd;
    }

    private void OnGameEnd(string reason)
    {
        Show();
    }

    private void Show()
    {
        ResultScreen.SetActive(true);
    }

    private void Hide()
    {
        ResultScreen.SetActive(false);
    }
}
