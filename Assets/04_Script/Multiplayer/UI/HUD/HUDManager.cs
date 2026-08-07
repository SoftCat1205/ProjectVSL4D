using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance { get; private set; }

    [Header("UI")]
    [SerializeField] private HealthUI healthUI;
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private EquipmentUI equipmentUI;
    [SerializeField] private WeaponUI weaponUI;

    private PlayerStats _playerStats;
    private InventoryManager _inventoryManager;
    private EquipmentManager _equipmentManager;
    private WeaponManager _weaponManager;

    private void Awake()
    {
        Instance = this;
    }

    public void Initialize(Player player)
    {
        _playerStats = player.GetComponent<PlayerStats>();
        _inventoryManager = player.GetComponentInChildren<InventoryManager>();
        _equipmentManager = player.GetComponentInChildren<EquipmentManager>();
        _weaponManager = player.GetComponentInChildren<WeaponManager>();

        healthUI.Initialize(_playerStats);
        inventoryUI.Initialize(_inventoryManager);
        equipmentUI.Initialize(_equipmentManager);
        weaponUI.Initialize(_weaponManager);

        Debug.Log("HUD Initialized : HUD Side");
    }
}
