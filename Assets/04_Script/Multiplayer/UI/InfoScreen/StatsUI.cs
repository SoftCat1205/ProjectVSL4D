using UnityEngine;

public class StatsUI : MonoBehaviour
{
    private PlayerStats _playerStats;

    public void Initialize(PlayerStats playerStats)
    {
        _playerStats = playerStats;

        _playerStats.StatsUpdate += Refresh;

        Refresh(playerStats);
    }

    private void Refresh(PlayerStats playerStats)
    {

    }
}