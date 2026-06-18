using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class StatScreenController : MonoBehaviour
{
    public GameObject StatScreen;

    [SerializeField] private Player player;

    [Header("Current Stat Displays")]
    [SerializeField] private TextMeshProUGUI _playerNameDisplay;
    [SerializeField] private TextMeshProUGUI _currentMaxHealthDisplay;
    [SerializeField] private TextMeshProUGUI _currentHealthDisplay;
    [SerializeField] private TextMeshProUGUI _currentRecoveryDisplay;
    [SerializeField] private TextMeshProUGUI _currentArmourDisplay;
    [SerializeField] private TextMeshProUGUI _currentAbilityHasteDisplay;
    [SerializeField] private TextMeshProUGUI _currentMoveSpeedDisplay;
    [SerializeField] private TextMeshProUGUI _currentVisionDisplay;

    private bool _isStatScreenOpen = false;

    private void Awake()
    {
        StatScreen.SetActive(false);
    }

    private void Start()
    {
        InputManager.Instance.inputActions.Player.Status.performed += OnStatus;
        player.Stats.StatUpdate += OnRefresh;
    }

    private void OnDisable()
    {
        InputManager.Instance.inputActions.Player.Status.performed -= OnStatus;
        player.Stats.StatUpdate -= OnRefresh;
    }

    private void OnStatus(InputAction.CallbackContext context)
    {
        OnOff();
    }

    public void OnOff()
    {
        if (!GameManager.Instance.IsGameOver)
        {
            _isStatScreenOpen = !_isStatScreenOpen;
            StatScreen.SetActive(_isStatScreenOpen);
        }
    }

    private void OnRefresh(PlayerStats playerStats)
    {
        _playerNameDisplay.text = playerStats.PlayerName;
        _currentRecoveryDisplay.text = "Max Health: " + playerStats.CurrentMaxHealth;
        _currentHealthDisplay.text = "_current Health: " + playerStats.CurrentHealth;
        _currentRecoveryDisplay.text = "Recovery: " + playerStats.CurrentRecovery;
        _currentArmourDisplay.text = "Armour: " + playerStats.CurrentArmour;
        _currentAbilityHasteDisplay.text = "Ability Haste: " + playerStats.CurrentAbilityHaste;
        _currentMoveSpeedDisplay.text = "Move Speed: " + playerStats.CurrentMoveSpeed;
        _currentVisionDisplay.text = "Vision: " + playerStats.CurrentVision;
    }
}
