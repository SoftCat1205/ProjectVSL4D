using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class SettingScreenController : MonoBehaviour
{
    public GameObject SettingScreen;

    private bool _isSettingScreenOpen = false;

    private void Awake()
    {
        SettingScreen.SetActive(false);
    }

    private void OnEnable()
    {
        InputManager.Instance.inputActions.Player.Setting.performed += OnSetting;
    }

    private void OnDisable()
    {
        InputManager.Instance.inputActions.Player.Setting.performed -= OnSetting;
    }

    public void OnSetting(InputAction.CallbackContext context)
    {
        OnOff();
    }

    public void OnOff()
    {
        if (!GameManager.Instance.IsGameOver)
        {
            _isSettingScreenOpen = !_isSettingScreenOpen;
            SettingScreen.SetActive(_isSettingScreenOpen);
        }
    }
}
