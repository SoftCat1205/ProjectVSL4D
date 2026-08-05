using UnityEngine;

public class MHealthUI : MonoBehaviour
{
    private MPlayerStats _playerStats;

    public void Initialize(MPlayerStats playerStats)
    {
        _playerStats = playerStats;

        _playerStats.StatsUpdate += Refresh;

        Refresh();
    }

    private void Refresh()
    {

    }
}