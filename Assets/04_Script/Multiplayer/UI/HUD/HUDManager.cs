using UnityEngine;

public class MHUDManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private HealthUI healthUI;
    [SerializeField] private StatsUI statsUI;
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private EquipmentUI equipmentUI;
    [SerializeField] private WeaponUI weaponUI;

    private PlayerStats _playerStats;
    private InventoryManager _inventory;
    private EquipmentManager _equipmentManager;
    private WeaponManager _weaponManager;

    public void Initialize(Player player)
    {
        _playerStats = player.GetComponent<PlayerStats>();
        _inventory = player.GetComponent<InventoryManager>();
        _equipmentManager = player.GetComponent<EquipmentManager>();
        _weaponManager = player.GetComponent<WeaponManager>();

        healthUI.Initialize(_playerStats);
        statsUI.Initialize(_playerStats);
        inventoryUI.Initialize(_inventory);
        equipmentUI.Initialize(_equipmentManager);
        weaponUI.Initialize(_weaponManager);
    }
}
