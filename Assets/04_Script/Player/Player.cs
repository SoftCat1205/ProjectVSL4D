using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerID { get; private set; }

    public PlayerMovement Movement { get; private set; }
    public PlayerAnimator Animator { get; private set; }
    public PlayerStats Stats { get; private set; }
    public PlayerInventory Inventory { get; private set; }
    public PlayerStatistics Statistics { get; private set; }
    public HUDController HUD { get; private set; }
    //Temp
    public PlayerWeaponManager WeaponManager { get; private set; }
    public PlayerEquipmentManager EquipmentManager { get; private set; }

    private void Awake()
    {
        Movement = GetComponent<PlayerMovement>();
        Animator = GetComponent<PlayerAnimator>();
        Stats = GetComponent<PlayerStats>();
        Inventory = GetComponent<PlayerInventory>();
        Statistics = GetComponent<PlayerStatistics>();
        WeaponManager = GetComponent<PlayerWeaponManager>();
        EquipmentManager = GetComponent<PlayerEquipmentManager>();
        HUD = GetComponent<HUDController>();
    }

    private void Start()
    {
        PlayerManager.Instance.RegisterPlayer(this);

        HUD.Initialize(this);
    }

    private void OnDestroy()
    {
        if (PlayerManager.Instance != null)
        {
            PlayerManager.Instance.UnregisterPlayer(this);
        }
    }
}