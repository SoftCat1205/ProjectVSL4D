using UnityEngine;

[RequireComponent(typeof(Player))]
public class HUDController : MonoBehaviour
{
    [Header("UI Slots")]
    [SerializeField] private GameObject _hud;
    [SerializeField] private EquipmentBarUIContoller _equipmentBarUI;
    [SerializeField] private HealthBarUIController _healthBarUI;
    [SerializeField] private InventoryBarUIController _inventoryBarUI;
    [SerializeField] private StatusBarUIController _statusBarUI;
    [SerializeField] private TimerBarUIController _timerUI;
    [SerializeField] private WeaponBarUIController _weaponBarUI;

    private Player _player;

    public void Initialize(Player player)
    {
        _player = player;

        _equipmentBarUI.Initialize(_player);
        _healthBarUI.Initialize(_player);
        _inventoryBarUI.Initialize(_player);
        _statusBarUI.Initialize(_player);
        _timerUI.Initialize(_player);
        _weaponBarUI.Initialize(_player);
    }
}
