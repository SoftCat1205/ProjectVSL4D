using UnityEngine;

public class MHUDManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private MHealthUI healthUI;
    [SerializeField] private MStatsUI statsUI;
    [SerializeField] private MInventoryUI inventoryUI;
    [SerializeField] private MEquipmentUI equipmentUI;
    [SerializeField] private MWeaponUI weaponUI;

    private MPlayerStats _playerStats;
    private MInventory _inventory;
    private MEquipmentManager _equipmentManager;
    private MWeaponManager _weaponManager;

    public void Initialize(MPlayer player)
    {
        _playerStats = player.GetComponent<MPlayerStats>();
        _inventory = player.GetComponent<MInventory>();
        _equipmentManager = player.GetComponent<MEquipmentManager>();
        _weaponManager = player.GetComponent<MWeaponManager>();

        healthUI.Initialize(_playerStats);
        statsUI.Initialize(_playerStats);
        inventoryUI.Initialize(_inventory);
        equipmentUI.Initialize(_equipmentManager);
        weaponUI.Initialize(_weaponManager);
    }
}
