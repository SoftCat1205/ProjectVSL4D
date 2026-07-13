using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class MPlayerWeapon : NetworkBehaviour
{
    [Header("Weapon Slots")]
    [SerializeField] private List<MWeapon> weapons = new(4);

    [Header("Weapon Positions")]
    [SerializeField] private List<Transform> weaponPositions = new(4);

    public void EquipWeapon(MWeapon weapon, int index)
    {
        Runner.Spawn(weapon, weaponPositions[index].position, weaponPositions[index].rotation);

        weapons[index] = weapon;

        weapon.transform.SetParent(weaponPositions[index]);
    }

    public void Activate(NetworkInputData input, Vector2 direction)
    {
        if (input.Buttons.IsSet(InputButtons.LeftArm))
        {
            if (weapons[0] != null)
                weapons[0].Activate(direction);
        }

        if (input.Buttons.IsSet(InputButtons.RightArm))
        {
            if (weapons[1] != null)
                weapons[1].Activate(direction);
        }

        if (input.Buttons.IsSet(InputButtons.LeftBack))
        {
            if (weapons[2] != null)
                weapons[2].Activate(direction);
        }

        if (input.Buttons.IsSet(InputButtons.RightBack))
        {
            if (weapons[3] != null)
                weapons[3].Activate(direction);
        }
    }
}