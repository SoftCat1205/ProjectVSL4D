using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(PlayerStats))]
[RequireComponent(typeof(PlayerInventory))]
[RequireComponent(typeof(PlayerStatistics))]
public class Player : MonoBehaviour
{
    public int PlayerID { get; private set; }

    public PlayerMovement Movement { get; private set; }
    public PlayerAnimator Animator { get; private set; }
    public PlayerStats Stats { get; private set; }
    public PlayerInventory Inventory { get; private set; }
    public PlayerStatistics Statistics { get; private set; }

    private void Awake()
    {
        PlayerManager.Instance.RegisterPlayer(this);

        Movement = GetComponent<PlayerMovement>();
        Animator = GetComponent<PlayerAnimator>();
        Stats = GetComponent<PlayerStats>();
        Inventory = GetComponent<PlayerInventory>();
        Statistics = GetComponent<PlayerStatistics>();
    }

    private void OnDestroy()
    {
        if (PlayerManager.Instance != null)
        {
            PlayerManager.Instance.UnregisterPlayer(this);
        }
    }
}