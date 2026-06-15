using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    public List<Player> Players { get; private set; } = new(4);

    public int AlivePlayerCount { get; private set; }

    public event Action<string> AllPlayersDied;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void RegisterPlayer(Player player)
    {
        if (!Players.Contains(player) && Players.Count < 4)
        {
            Players.Add(player);
            AlivePlayerCount++;
            player.Stats.PlayerDied += OnPlayerDied;
        }
    }

    public void UnregisterPlayer(Player player)
    {
        player.Stats.PlayerDied -= OnPlayerDied;
        Players.Remove(player);
    }

    public Player GetPlayer(int id)
    {
        return Players.Find(p => p.PlayerID == id);
    }

    public List<Player> GetLivingPlayers()
    {
        return Players.FindAll(p => p.Stats.IsAlive == true);
    }

    public void OnPlayerDied(PlayerStats playerStats)
    {
        AlivePlayerCount--;

        if (AlivePlayerCount <= 0)
        {
            AllPlayersDied?.Invoke("All Players Died");
        }
    }
}