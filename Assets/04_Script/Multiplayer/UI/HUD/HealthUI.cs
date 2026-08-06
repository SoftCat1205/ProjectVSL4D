using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private TMP_Text healthText;

    private PlayerStats _playerStats;

    public void Initialize(PlayerStats playerStats)
    {
        _playerStats = playerStats;

        _playerStats.StatsUpdate += Refresh;

        Refresh(playerStats);
    }

    private void Refresh(PlayerStats playerStats)
    {
        healthBar.maxValue = _playerStats.MaxHealth;
        healthBar.value = _playerStats.Health;

        healthText.text = _playerStats.Health.ToString();
    }

    private void OnDestroy()
    {
        if (_playerStats != null)
            _playerStats.StatsUpdate -= Refresh;
    }
}