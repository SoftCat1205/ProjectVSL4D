using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    public List<WeaponController> weaponSlots = new(6);
    public int[] weaponLevels = new int[6];
    public List<Image> weaponUISlots = new(6);
    public List<PassiveItem> passiveItemSlots = new(6);
    public int[] passiveItemLevels = new int[6];
    public List<Image> passiveItemUISlots = new(6);

    void Awake()
    {
        Instance = this;
    }

    public void AddWeapon(int slotIndex, WeaponController weapon)
    {
        weaponSlots[slotIndex] = weapon;
        weaponLevels[slotIndex] = weapon.weaponData.Level;
        weaponUISlots[slotIndex].enabled = true;
        weaponUISlots[slotIndex].sprite = weapon.weaponData.Icon;
    }

    public void AddPassiveItem(int slotIndex, PassiveItem passiveItem)
    {
        passiveItemSlots[slotIndex] = passiveItem;
        passiveItemLevels[slotIndex] = passiveItem.passiveItemData.Level;
        passiveItemUISlots[slotIndex].enabled = true;
        passiveItemUISlots[slotIndex].sprite = passiveItem.passiveItemData.Icon;
    }

    public void LevelUpWeapon(int slotIndex)
    {
        if (slotIndex > weaponSlots.Count)
        {
            return;
        }
        WeaponController weapon = weaponSlots[slotIndex];
        if (weapon.weaponData.NextLevelPrefab == null)
        {
            Debug.Log("NO NEXT LEVEL WEAPOND PREFAB");
            return;
        }
        GameObject upgradedWeapon = Instantiate(weapon.weaponData.NextLevelPrefab, transform.position, Quaternion.identity);
        upgradedWeapon.transform.SetParent(transform);
        AddWeapon(slotIndex, upgradedWeapon.GetComponent<WeaponController>());
        Destroy(weapon.gameObject);
        weaponLevels[slotIndex] = upgradedWeapon.GetComponent<WeaponController>().weaponData.Level;
    }

    public void LevelUpPassiveItem(int slotIndex)
    {
        if (slotIndex > passiveItemSlots.Count)
        {
            return;
        }
        PassiveItem passiveItem = passiveItemSlots[slotIndex];
        if (passiveItem.passiveItemData.NextLevelPrefab == null)
        {
            Debug.Log("NO NEXT LEVEL PASSIVE ITEM PREFAB");
            return;
        }
        GameObject upgradedPassiveItem = Instantiate(passiveItem.passiveItemData.NextLevelPrefab, transform.position, Quaternion.identity);
        upgradedPassiveItem.transform.SetParent(transform);
        AddPassiveItem(slotIndex, upgradedPassiveItem.GetComponent<PassiveItem>());
        Destroy(passiveItem.gameObject);
        passiveItemLevels[slotIndex] = upgradedPassiveItem.GetComponent<PassiveItem>().passiveItemData.Level;
    }
}
