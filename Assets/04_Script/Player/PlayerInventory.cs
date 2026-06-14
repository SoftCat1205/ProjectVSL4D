using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    public List<WeaponController> weaponSlots = new(6);
    public int[] weaponLevels = new int[6];
    public List<Image> weaponUISlots = new(6);
    public int weaponIndex = 0;

    public List<PassiveItem> passiveItemSlots = new(6);
    public int[] passiveItemLevels = new int[6];
    public List<Image> passiveItemUISlots = new(6);
    public int passiveItemIndex = 0;

    [System.Serializable]
    public class WeaponUpgrade
    {
        public GameObject InitialWeapon;
        public WeaponScriptableObject WeaponData;
    }

    [System.Serializable]
    public class PassiveItemUpgrade
    {
        public GameObject InitialPassiveItem;
        public PassiveItemScriptableObject PassiveItemData;
    }

    [System.Serializable]
    public class UpgradeUI
    {
        public Text UpgradeDisplayNameDisplay;
        public Text UpgradeDiscriptionDisplay;
        public Image UpgradeIcon;
        public Button UpgradeButton;
    }

    public List<WeaponUpgrade> WeaponUpgradeOptions = new();
    public List<PassiveItemUpgrade> PassiveItemUpgradeOptions = new();
    public List<UpgradeUI> UpgradeUIOptions = new();

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

    }


    public void SpawnWeapon(GameObject weapon)
    {
        //Check if slots are full
        if (weaponIndex > weaponSlots.Count - 1)
        {
            Debug.Log("Weapon inventory is full");
            return;
        }

        GameObject spawnedWeapon = Instantiate(weapon, transform.position, quaternion.identity);
        spawnedWeapon.transform.SetParent(transform);
        AddWeapon(weaponIndex, spawnedWeapon.GetComponent<WeaponController>());

        weaponIndex++;
    }

    public void SpawnPassiveItem(GameObject passiveItem)
    {
        //Check if slots are full
        if (passiveItemIndex > passiveItemSlots.Count - 1)
        {
            Debug.Log("Weapon inventory is full");
            return;
        }

        GameObject spawnedPassiveItem = Instantiate(passiveItem, transform.position, quaternion.identity);
        spawnedPassiveItem.transform.SetParent(transform);
        AddPassiveItem(passiveItemIndex, spawnedPassiveItem.GetComponent<PassiveItem>());

        passiveItemIndex++;
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

    private void ApplyUpgradeOptions()
    {
        foreach (var upgradeOption in UpgradeUIOptions)
        {
            int upgradeType = UnityEngine.Random.Range(1, 3);
            if (upgradeType == 1)
            {
                WeaponUpgrade weaponUpgrade = WeaponUpgradeOptions[UnityEngine.Random.Range(0, WeaponUpgradeOptions.Count)];

                if (weaponUpgrade == null)
                {
                    return;
                }

                for (int i = 0; i < weaponSlots.Count; i++)
                {
                    if (weaponSlots[i] != null && weaponSlots[i] == weaponUpgrade.WeaponData)
                    {
                        upgradeOption.UpgradeButton.onClick.AddListener(() => LevelUpWeapon(i));
                        break;
                    }
                }
                upgradeOption.UpgradeDisplayNameDisplay.text = weaponUpgrade.WeaponData.DisplayName;
                upgradeOption.UpgradeDiscriptionDisplay.text = weaponUpgrade.WeaponData.Discription;
                upgradeOption.UpgradeIcon.sprite = weaponUpgrade.WeaponData.Icon;
            }
            else if (upgradeType == 2)
            {
                PassiveItemUpgrade passiveItemUpgrade = PassiveItemUpgradeOptions[UnityEngine.Random.Range(0, PassiveItemUpgradeOptions.Count)];

                if (passiveItemUpgrade == null)
                {
                    return;
                }

                for (int i = 0; i < passiveItemSlots.Count; i++)
                {
                    if (passiveItemSlots[i] != null && passiveItemSlots[i] == passiveItemUpgrade.PassiveItemData)
                    {
                        upgradeOption.UpgradeButton.onClick.AddListener(() => LevelUpPassiveItem(i));
                        break;
                    }
                }
                upgradeOption.UpgradeDisplayNameDisplay.text = passiveItemUpgrade.PassiveItemData.DisplayName;
                upgradeOption.UpgradeDiscriptionDisplay.text = passiveItemUpgrade.PassiveItemData.Discription;
                upgradeOption.UpgradeIcon.sprite = passiveItemUpgrade.PassiveItemData.Icon;
            }
        }
    }

    private void RemoveUpgradeOptions()
    {
        foreach (var upgradeOption in UpgradeUIOptions)
        {
            upgradeOption.UpgradeButton.onClick.RemoveAllListeners();
        }
    }

    private void RemoveAndApplyUpgradeOptions()
    {
        RemoveUpgradeOptions();
        ApplyUpgradeOptions();
    }
}
