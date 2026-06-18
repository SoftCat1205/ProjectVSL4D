using UnityEngine;

[RequireComponent(typeof(Player))]
public class HUDController : MonoBehaviour
{
    //UI Slots
    [SerializeField] private GameObject HUD;
    [SerializeField] private HealthBarUIController healthBarUI;
    [SerializeField] private WeaponBarUIController weaponBarUI;
    [SerializeField] private EquipmentBarUIContoller equipmentBarUI;
    [SerializeField] private InventoryBarUIController inventoryBarUI;
    [SerializeField] private StatusBarUIController statusBarUI;
    [SerializeField] private TimerBarUIController timerUI;

    private Player _player;

    private void Awake()
    {
        HUD.SetActive(true);
        _player = GetComponent<Player>();
    }
}
