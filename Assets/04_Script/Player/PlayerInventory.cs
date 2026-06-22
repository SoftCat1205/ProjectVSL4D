using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    public List<WeaponController> weaponSlots = new(4);
    public int[] weaponLevels = new int[4];
    public List<Image> weaponUISlots = new(4);
    public int weaponIndex = 0;

    public List<Equipment> EquipmentSlots = new(6);
    public int[] EquipmentLevels = new int[6];
    public List<Image> EquipmentUISlots = new(6);
    public int EquipmentIndex = 0;

    [System.Serializable]
    public class WeaponUpgrade
    {
        public GameObject InitialWeapon;
        public WeaponScriptableObject WeaponData;
    }

    [System.Serializable]
    public class EquipmentUpgrade
    {
        public GameObject InitialEquipment;
        public EquipmentScriptableObject EquipmentData;
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
    public List<EquipmentUpgrade> EquipmentUpgradeOptions = new();
    public List<UpgradeUI> UpgradeUIOptions = new();

    void Awake()
    {
        Instance = this;
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

    public void SpawnEquipment(GameObject Equipment)
    {
        //Check if slots are full
        if (EquipmentIndex > EquipmentSlots.Count - 1)
        {
            Debug.Log("Weapon inventory is full");
            return;
        }

        GameObject spawnedEquipment = Instantiate(Equipment, transform.position, quaternion.identity);
        spawnedEquipment.transform.SetParent(transform);
        AddEquipment(EquipmentIndex, spawnedEquipment.GetComponent<Equipment>());

        EquipmentIndex++;
    }

    public void AddWeapon(int slotIndex, WeaponController weapon)
    {
        weaponSlots[slotIndex] = weapon;
        weaponLevels[slotIndex] = weapon.WeaponData.Level;
        weaponUISlots[slotIndex].enabled = true;
        weaponUISlots[slotIndex].sprite = weapon.WeaponData.WeaponFamily.Icon;
    }

    public void AddEquipment(int slotIndex, Equipment Equipment)
    {
        EquipmentSlots[slotIndex] = Equipment;
        EquipmentLevels[slotIndex] = Equipment.EquipmentData.Level;
        EquipmentUISlots[slotIndex].enabled = true;
        EquipmentUISlots[slotIndex].sprite = Equipment.EquipmentData.Icon;
    }

    public void LevelUpWeapon(int slotIndex)
    {
        if (slotIndex > weaponSlots.Count)
        {
            return;
        }
        WeaponController weapon = weaponSlots[slotIndex];
        if (weapon.WeaponData.NextLevelWeaponData == null)
        {
            Debug.Log("NO NEXT LEVEL WEAPOND PREFAB");
            return;
        }
    }

    public void LevelUpEquipment(int slotIndex)
    {
        if (slotIndex > EquipmentSlots.Count)
        {
            return;
        }
        Equipment Equipment = EquipmentSlots[slotIndex];
        if (Equipment.EquipmentData.NextLevelPrefab == null)
        {
            Debug.Log("NO NEXT LEVEL PASSIVE ITEM PREFAB");
            return;
        }
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
                upgradeOption.UpgradeDisplayNameDisplay.text = weaponUpgrade.WeaponData.WeaponFamily.DisplayName;
                upgradeOption.UpgradeDiscriptionDisplay.text = weaponUpgrade.WeaponData.WeaponFamily.Discription;
                upgradeOption.UpgradeIcon.sprite = weaponUpgrade.WeaponData.WeaponFamily.Icon;
            }
            else if (upgradeType == 2)
            {
                EquipmentUpgrade EquipmentUpgrade = EquipmentUpgradeOptions[UnityEngine.Random.Range(0, EquipmentUpgradeOptions.Count)];

                if (EquipmentUpgrade == null)
                {
                    return;
                }

                for (int i = 0; i < EquipmentSlots.Count; i++)
                {
                    if (EquipmentSlots[i] != null && EquipmentSlots[i] == EquipmentUpgrade.EquipmentData)
                    {
                        upgradeOption.UpgradeButton.onClick.AddListener(() => LevelUpEquipment(i));
                        break;
                    }
                }
                upgradeOption.UpgradeDisplayNameDisplay.text = EquipmentUpgrade.EquipmentData.DisplayName;
                upgradeOption.UpgradeDiscriptionDisplay.text = EquipmentUpgrade.EquipmentData.Discription;
                upgradeOption.UpgradeIcon.sprite = EquipmentUpgrade.EquipmentData.Icon;
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
