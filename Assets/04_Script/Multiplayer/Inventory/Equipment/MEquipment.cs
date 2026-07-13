using Fusion;
using UnityEngine;

public class MEquipment : NetworkBehaviour
{
    [Networked] public NetworkObject Owner { get; set; }
    [Networked] public int SlotIndex { get; set; }

    [Header("Equipment Stats")]
    [SerializeField] protected EquipmentScriptableObject equipmentData;
    public EquipmentScriptableObject EquipmentData => equipmentData;
    public int Level => EquipmentData.Level;

    protected float _currentCooldown = 0;
    public float CurrentCooldown => _currentCooldown;

    protected void Update()
    {
        if (_currentCooldown == 0f)
            return;

        if (_currentCooldown < 0f)
            _currentCooldown = 0f;

        if (_currentCooldown > 0f)
            _currentCooldown -= Time.deltaTime;
    }

    public virtual void Activate()
    {
        if (_currentCooldown <= 0f)
        {
            Debug.Log("Activated Weapon!");
            _currentCooldown = EquipmentData.Cooldown;
        }
    }

    public void LevelUp()
    {
        if (EquipmentData.NextLevelEquipmentData == null)
        {
            Debug.Log("Max Level.");
            return;
        }

        equipmentData = EquipmentData.NextLevelEquipmentData;
    }
}